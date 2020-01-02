using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootballScoresApp.Model.MatchEventModels;

namespace FootballScoresApp.Model
{
    public class MatchEvent : Match
    {
        public string match_hometeam_extra_score { get; set; }
        public string match_awayteam_extra_score { get; set; }
        public string match_hometeam_penalty_score { get; set; }
        public string match_awayteam_penalty_score { get; set; }
        public string match_hometeam_ft_score { get; set; }
        public string match_awayteam_ft_score { get; set; }
        public string match_hometeam_system { get; set; }
        public string match_awayteam_system { get; set; }

        public List<GoalScorer> goalscorer { get; set; }
        public List<CardInfo> cards { get; set; }
        public Substitutions substitutions { get; set; }
        public Lineup lineup { get; set; }
        public List<Statistic> statistics { get; set; }

        public override string ToString()
        {
            if (match_live.Equals("1"))
                return $"{match_date} | {match_hometeam_name} {match_hometeam_score}:{match_awayteam_score} {match_awayteam_name} | {match_status}\' |";
            else if (match_status == "Finished")
                return $"{match_date} | {match_time} | {match_hometeam_name} {match_hometeam_score}:{match_awayteam_score} {match_awayteam_name}";
            else
                return $"{match_date} | {match_time} | {match_hometeam_name} vs. {match_awayteam_name}";
        }
    }
}
