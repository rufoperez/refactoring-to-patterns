using System.Reflection.Emit;

namespace RefactoringToPatterns.CreationMethods
{
    public class ProductPackage
    {
        private readonly string _internetLabel;
        private readonly int? _telephoneNumber;
        private readonly string[] _tvChannels;
        private readonly int? _cellNumber;

        private ProductPackage(string internetLabel, int? telephoneNumber, string[] tvChannels, int? cellNumber)
        {
            _internetLabel = internetLabel;
            _telephoneNumber = telephoneNumber;
            _tvChannels = tvChannels;
            _cellNumber = cellNumber;
        }

        public bool HasInternet()
        {
            return _internetLabel != null;
        }


        public bool HasVOIP()
        {
            return _telephoneNumber != null;
        }

        public bool HasTv()
        {
            return _tvChannels != null;
        }

        public bool HasCellNumber()
        {
            return _cellNumber != null;
        }

        public static ProductPackage CreateInternet(string internetLabel)
        {
            return new ProductPackage(internetLabel, null, null, null);
        }

        public static ProductPackage CreateInternetAndVoip(string internetLabel, int telephoneNumber)
        {
            return new ProductPackage(internetLabel, telephoneNumber, null, null);
        }

        public static ProductPackage CreateInternetAndTv(string internetLabel, string[] tvChannels)
        {
            return new ProductPackage(internetLabel, null, tvChannels, null);
        }

        public static ProductPackage CreateInternetAndVoipAndTv(string internetLabel, int telephoneNumber, string[] tvChannels)
        {
            return new ProductPackage(internetLabel, telephoneNumber, tvChannels, null);
        }

        public static ProductPackage CreateInternetAndCellNumber(string internetLabel, int cellNumber)
        {
            return new ProductPackage(internetLabel, null, null, cellNumber);
        }
    }
}