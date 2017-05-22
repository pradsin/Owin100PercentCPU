using System.Collections.Generic;
using System.Threading.Tasks;

namespace OwinSelfHost.Controllers
{
    public class QuotesController : BaseController
    {
        #region Static Fields and Constants

        private static readonly List<string> Quotes = new List<string>
        {
            "Reading is to the mind what exercise is to the body. - Joseph Addison",
            "Glory is fleeting, but obscurity is forever. - Napoleon Bonaparte",
            "If you want to be loved, be lovable. - Ovid",
            "Art is either plagiarism or revolution. - Paul Gauguin",
            "The groves were God's first temples. - William C. Bryant",
            "Life is a zoo in a jungle. - Peter De Vries",
            "Problems are not the problem; coping is the problem. - Virginia Satir",
            "It's not the having, it's the getting. - Elizabeth Taylor",
            "There is only one real deprivation... and that is not to be able to give one's gifts to those one loves most. - May Sarton",
            "An artist is forced by others to paint out of his own free will. - Willem de Kooning",
            "Self-preservation is the first law of nature. - Samuel Butler",
            "One advantage of talking to yourself is that you know at least somebody's listening. - Franklin P. Jones",
            "Reggie Jackson, Frank Capra, Pope John Paul II, Bertrand Russell, Tina Fey",
            "Give light and people will find the way. - Ella Baker",
            "Boldness is a mask for fear, however great. - John Dryden",
            "So, fall asleep love, loved by me... for I know love, I am loved by thee. - Robert Browning",
            "Art is nature speeded up and God slowed down. - Malcolm de Chazal",
            "Sit in reverie and watch the changing color of the waves that break upon the idle seashore of the mind. - Henry Wadsworth Longfellow",
            "Macho does not prove mucho. - Zsa Zsa Gabor"
        };

        #endregion

        #region Public Methods

        public async Task<List<string>> Get()
        {
            return await Task.FromResult(Quotes);
        }

        #endregion
    }
}