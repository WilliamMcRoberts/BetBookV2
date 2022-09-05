﻿using BetBookGamingData.Models;

namespace BetBookGamingData.Helpers;


#nullable enable

public static class CalculationHelpers
{

    //public static TeamModel CalculateWinningTeam(this GameModel game,
    //                                             double? homeTeamFinalScore, 
    //                                             double? awayTeamFinalScore,
    //                                             IEnumerable<TeamModel> teams)
    //{

    //    TeamModel? homeTeam = 
    //        teams.Where(t => t.Id == game.HomeTeamId).FirstOrDefault();
    //    TeamModel? awayTeam = 
    //        teams.Where(t => t.Id == game.AwayTeamId).FirstOrDefault();

    //    TeamModel? winner = (homeTeamFinalScore == awayTeamFinalScore) ? null :
    //        (homeTeamFinalScore > awayTeamFinalScore) ? homeTeam :
    //            awayTeam;

    //    return winner!;
    //}

    public static int CalculateWeek(this SeasonType season, DateTime dateTime)
    {
        int week = season == SeasonType.PRE ? (dateTime - new DateTime(2022, 8, 9)).Days / 7
                   : season == SeasonType.REG ? (dateTime - new DateTime(2022, 9, 4)).Days / 7
                   : (dateTime - new DateTime(2023, 1, 14)).Days / 7;

        if (week < 0)
            return 0;

        return week + 1;
    }

    public static SeasonType CalculateSeason(this DateTime dateTime)
    {
        return dateTime > new DateTime(2022, 8, 9) && dateTime < new DateTime(2022, 8, 28) ? SeasonType.PRE
            : dateTime > new DateTime(2022, 8, 28) && dateTime < new DateTime(2023, 1, 14) ? SeasonType.REG
            : SeasonType.POST;
    }

    public static decimal CalculateParleyBetPayout(this int gamecount, decimal betAmount)
    { 
        betAmount -= betAmount * (decimal).1;

        return gamecount == 2 ? betAmount * (decimal)2.6 
            : gamecount == 3 ? betAmount * (decimal)6 
            : gamecount == 4 ? betAmount * (decimal)11 
            : betAmount * (decimal)22;
    }
}

#nullable restore
