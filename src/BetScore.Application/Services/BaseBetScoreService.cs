using BetScore.Application.ViewModels;

namespace BetScore.Application.Services
{
    public class BaseBetScoreService
    {
        public BaseBetScoreService()
        {
            ResponseBase = new ResponseBase();
        }

        public ResponseBase ResponseBase { get; set; }
    }
}
