﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using RiotGamesApi.Cache;
using RiotGamesApi.RateLimit;
using RiotGamesApi.RateLimit.Builder;

namespace RiotGamesApi.AspNetCore
{
	public static class Extension
	{
		/// <summary>
		/// necessary for using LeagueOfLegendsApi 
		/// </summary>
		/// <param name="services">
		/// </param>
		/// <param name="riotApiKey">
		/// RiotGames DeveloperKey or ProductionKey 
		/// </param>
		/// <exception cref="Exception">
		/// A delegate callback throws an exception. 
		/// </exception>
		public static void AddLeagueOfLegendsApi(this IServiceCollection services, string riotApiKey)
		{
			services.AddLeagueOfLegendsApi(riotApiKey, null, null);
		}

		/// <summary>
		/// necessary for using LeagueOfLegendsApi 
		/// </summary>
		/// <param name="services">
		/// </param>
		/// <param name="riotApiKey">
		/// RiotGames DeveloperKey or ProductionKey 
		/// </param>
		/// <param name="cacheOption">
		/// custom api caching options (default: ApiCaching is NOT USED ) 
		/// </param>
		/// <exception cref="Exception">
		/// A delegate callback throws an exception. 
		/// </exception>
		public static void AddLeagueOfLegendsApi(this IServiceCollection services, string riotApiKey,
			Func<CacheOption, CacheOption> cacheOption)
		{
			services.AddLeagueOfLegendsApi(riotApiKey, cacheOption, null);
		}

		/// <summary>
		/// A delegate callback throws an exception. 
		/// </summary>
		/// <param name="services">
		/// </param>
		/// <param name="riotApiKey">
		/// </param>
		/// <param name="rateLimitOption2">
		/// </param>
		public static void AddLeagueOfLegendsApi(this IServiceCollection services, string riotApiKey,
			Func<RateLimitBuilder, RateLimitBuilder> rateLimitOption2)
		{
			services.AddLeagueOfLegendsApi(riotApiKey, null, rateLimitOption2);
		}

		/// <summary>
		/// necessary for using RiotGamesApi.AspNetCore wrapper 
		/// </summary>
		/// <param name="app">
		/// </param>
		/// <returns>
		/// </returns>
		public static IApplicationBuilder UseRiotGamesApi(this IApplicationBuilder app)
		{
			IServiceProvider sProvider = app.ApplicationServices;
			sProvider.UseRiotGamesApi();
			return app;
		}
	}
}