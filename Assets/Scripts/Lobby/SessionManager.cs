using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Unity.Services.Authentication;
using Unity.Services.Core;
using Unity.Services.Multiplayer;
using UnityEngine;
using UnityUtils;
// NETWORKING TUTORIALS:
    // 1st:       https://www.youtube.com/watch?v=Ndixa64p3dQ
    // 2nd:       https://www.youtube.com/watch?v=SZjpm950g_c 
//
public class SessionManager : Singleton<SessionManager> {
    ISession activeSession;

    ISession ActiveSession {
        get => activeSession;
        set {
            activeSession = value;
            Debug.Log($"Active session: {activeSession}");
        }
    }
    
    const string playerNamePropertyKey = "playerName";

    async void Start() {
        try {
            await UnityServices.InitializeAsync(); // Initialize Unity Gaming Services SDKs.
            await AuthenticationService.Instance.SignInAnonymouslyAsync(); // Anonymously authenticate the player
            Debug.Log($"Sign in anonymously succeeded! PlayerID: {AuthenticationService.Instance.PlayerId}");
            
            // Start a new session as a host
            StartSessionAsHost();
        }
        catch (Exception e) {
            Debug.LogException(e);
        }
    }

    async UniTask<Dictionary<string, PlayerProperty>> GetPlayerProperties() {
        // Custom game-specific properties that apply to an individual player, ie: name, role, skill level, etc.
        var playerName = await AuthenticationService.Instance.GetPlayerNameAsync();
        var playerNameProperty = new PlayerProperty(playerName, VisibilityPropertyOptions.Member);
        return new Dictionary<string, PlayerProperty> { { playerNamePropertyKey, playerNameProperty } };
    }

    async void StartSessionAsHost() {
        var playerProperties = await GetPlayerProperties(); 
        
        var options = new SessionOptions {
            MaxPlayers = 2,
            IsLocked = false,
            IsPrivate = false,
            PlayerProperties = playerProperties 
        }.WithRelayNetwork(); // or WithDistributedAuthorityNetwork() to use Distributed Authority instead of Relay
        
        ActiveSession = await MultiplayerService.Instance.CreateSessionAsync(options);
        Debug.Log($"Session {ActiveSession.Id} created! Join code: {ActiveSession.Code}");
    }

    async UniTaskVoid JoinSessionById(string sessionId) {
        ActiveSession = await MultiplayerService.Instance.JoinSessionByIdAsync(sessionId);
        Debug.Log($"Session {ActiveSession.Id} joined!");
    }

    async UniTaskVoid JoinSessionByCode(string sessionCode) {
        ActiveSession = await MultiplayerService.Instance.JoinSessionByCodeAsync(sessionCode);
        Debug.Log($"Session {ActiveSession.Id} joined!");
    }

    async UniTaskVoid KickPlayer(string playerId) {
        if (!ActiveSession.IsHost) return;
        await ActiveSession.AsHost().RemovePlayerAsync(playerId);
    }

    async UniTask<IList<ISessionInfo>> QuerySessions() {
        var sessionQueryOptions = new QuerySessionsOptions();
        QuerySessionsResults results = await MultiplayerService.Instance.QuerySessionsAsync(sessionQueryOptions);
        return results.Sessions;
    }

    async UniTaskVoid LeaveSession() {
        if (ActiveSession != null) {
            try {
                await ActiveSession.LeaveAsync();
            }
            catch {
                // Ignored as we are exiting the game
            }
            finally {
                ActiveSession = null;
            }
        }
    }
}