using System.Collections.Generic;

namespace DartGame.Models
{
    public class DartFinishes
    {
        #region Properties

        public Dictionary<int, DartFinishValues> DartFinishesList { get; private set; }

        #endregion

        #region Contructor

        public DartFinishes()
        {
            InitializeList();
        }

        #endregion

        #region Private Methods

        private void InitializeList()
        {
            PopulateThreeDartFinishes();
            PopulateTwoDartFinishes();
        }

        private void PopulateThreeDartFinishes()
        {
            DartFinishesList = new Dictionary<int, DartFinishValues>();

            DartFinishesList.Add(170, new DartFinishValues("T20", "T20", "D25"));
            DartFinishesList.Add(167, new DartFinishValues("T20", "T19", "D25"));
            DartFinishesList.Add(164, new DartFinishValues("T20", "T18", "D25"));
            DartFinishesList.Add(161, new DartFinishValues("T20", "T17", "D25"));
            DartFinishesList.Add(160, new DartFinishValues("T20", "T20", "D20"));
            DartFinishesList.Add(158, new DartFinishValues("T20", "T20", "D19"));
            DartFinishesList.Add(157, new DartFinishValues("T20", "T19", "D20"));
            DartFinishesList.Add(156, new DartFinishValues("T20", "T20", "D18"));
            DartFinishesList.Add(155, new DartFinishValues("T20", "T19", "D19"));
            DartFinishesList.Add(154, new DartFinishValues("T20", "T18", "D20"));
            DartFinishesList.Add(153, new DartFinishValues("T20", "T19", "D18"));
            DartFinishesList.Add(152, new DartFinishValues("T20", "T20", "D16"));
            DartFinishesList.Add(151, new DartFinishValues("T20", "T17", "D20"));
            DartFinishesList.Add(150, new DartFinishValues("T20", "T18", "D18"));
            DartFinishesList.Add(149, new DartFinishValues("T20", "T19", "D16"));
            DartFinishesList.Add(148, new DartFinishValues("T20", "T20", "D14"));
            DartFinishesList.Add(147, new DartFinishValues("T20", "T17", "D18"));
            DartFinishesList.Add(146, new DartFinishValues("T20", "T18", "D16"));
            DartFinishesList.Add(145, new DartFinishValues("T20", "T19", "D14"));
            DartFinishesList.Add(144, new DartFinishValues("T20", "T20", "D12"));
            DartFinishesList.Add(143, new DartFinishValues("T19", "T18", "D16"));
            DartFinishesList.Add(142, new DartFinishValues("T20", "T14", "D20"));
            DartFinishesList.Add(141, new DartFinishValues("T20", "T19", "D12"));
            DartFinishesList.Add(140, new DartFinishValues("T20", "T20", "D10"));
            DartFinishesList.Add(139, new DartFinishValues("T19", "T14", "D20"));
            DartFinishesList.Add(138, new DartFinishValues("T20", "T18", "D12"));
            DartFinishesList.Add(137, new DartFinishValues("T20", "T19", "D10"));
            DartFinishesList.Add(136, new DartFinishValues("T20", "T20", "D8"));
            DartFinishesList.Add(135, new DartFinishValues("T20", "T17", "D12"));
            DartFinishesList.Add(134, new DartFinishValues("T20", "T14", "D16"));
            DartFinishesList.Add(133, new DartFinishValues("T20", "T19", "D8"));
            DartFinishesList.Add(132, new DartFinishValues("T20", "T16", "D12"));
            DartFinishesList.Add(131, new DartFinishValues("T20", "T13", "D16"));
            DartFinishesList.Add(130, new DartFinishValues("T20", "T18", "D8"));
            DartFinishesList.Add(129, new DartFinishValues("T19", "T16", "D12"));
            DartFinishesList.Add(128, new DartFinishValues("T18", "T14", "D16"));
            DartFinishesList.Add(127, new DartFinishValues("T20", "T17", "D8"));
            DartFinishesList.Add(126, new DartFinishValues("T19", "T15", "D12"));
            DartFinishesList.Add(125, new DartFinishValues("T18", "T13", "D16"));
            DartFinishesList.Add(124, new DartFinishValues("T20", "T16", "D8"));
            DartFinishesList.Add(123, new DartFinishValues("T19", "T14", "D12"));
            DartFinishesList.Add(122, new DartFinishValues("T18", "T18", "D7"));
            DartFinishesList.Add(121, new DartFinishValues("T20", "T11", "D14"));
            DartFinishesList.Add(120, new DartFinishValues("T20", "S20", "D20"));
            DartFinishesList.Add(119, new DartFinishValues("T19", "T12", "D13"));
            DartFinishesList.Add(118, new DartFinishValues("T20", "S18", "D20"));
            DartFinishesList.Add(117, new DartFinishValues("T20", "S17", "D20"));
            DartFinishesList.Add(116, new DartFinishValues("T20", "S16", "D20"));
            DartFinishesList.Add(115, new DartFinishValues("T19", "S18", "D20"));
            DartFinishesList.Add(114, new DartFinishValues("T20", "S14", "D20"));
            DartFinishesList.Add(113, new DartFinishValues("T19", "S16", "D20"));
            DartFinishesList.Add(112, new DartFinishValues("T20", "T12", "D8"));
            DartFinishesList.Add(111, new DartFinishValues("T19", "S14", "D20"));
            DartFinishesList.Add(110, new DartFinishValues("T20", "S10", "D20"));
            DartFinishesList.Add(109, new DartFinishValues("T20", "S9", "D20"));
            DartFinishesList.Add(108, new DartFinishValues("T19", "S19", "D16"));
            DartFinishesList.Add(107, new DartFinishValues("T20", "S15", "D16"));
            DartFinishesList.Add(106, new DartFinishValues("T20", "S6", "D20"));
            DartFinishesList.Add(105, new DartFinishValues("T19", "S8", "D20"));
            DartFinishesList.Add(104, new DartFinishValues("T20", "T12", "D4"));
            DartFinishesList.Add(103, new DartFinishValues("T17", "S12", "D20"));
            DartFinishesList.Add(102, new DartFinishValues("T20", "S10", "D16"));
            DartFinishesList.Add(101, new DartFinishValues("T17", "S10", "D20"));
            DartFinishesList.Add(99, new DartFinishValues("T19", "S10", "D16"));
        }

        private void PopulateTwoDartFinishes() 
        {
            DartFinishesList.Add(100, new DartFinishValues("T20", "D20"));
            DartFinishesList.Add(98, new DartFinishValues("T20", "D19"));
            DartFinishesList.Add(97, new DartFinishValues("T19", "D20"));
            DartFinishesList.Add(96, new DartFinishValues("T20", "D18"));
            DartFinishesList.Add(95, new DartFinishValues("T19", "D19"));
            DartFinishesList.Add(94, new DartFinishValues("T18", "D20"));
            DartFinishesList.Add(93, new DartFinishValues("T19", "D18"));
            DartFinishesList.Add(92, new DartFinishValues("T20", "D16"));
            DartFinishesList.Add(91, new DartFinishValues("T17", "D20"));
            DartFinishesList.Add(89, new DartFinishValues("T19", "D16"));
            DartFinishesList.Add(88, new DartFinishValues("T16", "D20"));
            DartFinishesList.Add(87, new DartFinishValues("T17", "D18"));
            DartFinishesList.Add(86, new DartFinishValues("T18", "D16"));
            DartFinishesList.Add(85, new DartFinishValues("T15", "D20"));
            DartFinishesList.Add(84, new DartFinishValues("T20", "D12"));
            DartFinishesList.Add(83, new DartFinishValues("T17", "D16"));
            DartFinishesList.Add(82, new DartFinishValues("T14", "D20"));
            DartFinishesList.Add(81, new DartFinishValues("T19", "D12"));
            DartFinishesList.Add(80, new DartFinishValues("T20", "D10"));
            DartFinishesList.Add(79, new DartFinishValues("T13", "D20"));
            DartFinishesList.Add(78, new DartFinishValues("T18", "D12"));
            DartFinishesList.Add(77, new DartFinishValues("T15", "D16"));
            DartFinishesList.Add(76, new DartFinishValues("T20", "D8"));
            DartFinishesList.Add(75, new DartFinishValues("T17", "D12"));
            DartFinishesList.Add(74, new DartFinishValues("T14", "D16"));
            DartFinishesList.Add(73, new DartFinishValues("T19", "D8"));
            DartFinishesList.Add(72, new DartFinishValues("T16", "D12"));
            DartFinishesList.Add(71, new DartFinishValues("T13", "D16"));
            DartFinishesList.Add(70, new DartFinishValues("T18", "D8"));
            DartFinishesList.Add(69, new DartFinishValues("T19", "D6"));
            DartFinishesList.Add(68, new DartFinishValues("T20", "D4"));
            DartFinishesList.Add(67, new DartFinishValues("T17", "D8"));
            DartFinishesList.Add(66, new DartFinishValues("T14", "D12"));
            DartFinishesList.Add(65, new DartFinishValues("T19", "D4"));
            DartFinishesList.Add(64, new DartFinishValues("T16", "D8"));
            DartFinishesList.Add(63, new DartFinishValues("T13", "D12"));
            DartFinishesList.Add(62, new DartFinishValues("T10", "D16"));
            DartFinishesList.Add(61, new DartFinishValues("T15", "D8"));
            DartFinishesList.Add(60, new DartFinishValues("S20", "D20"));
            DartFinishesList.Add(59, new DartFinishValues("S19", "D20"));
            DartFinishesList.Add(58, new DartFinishValues("S18", "D20"));
            DartFinishesList.Add(57, new DartFinishValues("S17", "D20"));
            DartFinishesList.Add(56, new DartFinishValues("T16", "D4"));
            DartFinishesList.Add(55, new DartFinishValues("S15", "D20"));
            DartFinishesList.Add(54, new DartFinishValues("S14", "D20"));
            DartFinishesList.Add(53, new DartFinishValues("S12", "D20"));
            DartFinishesList.Add(52, new DartFinishValues("S12", "D20"));
            DartFinishesList.Add(51, new DartFinishValues("S11", "D20"));
            DartFinishesList.Add(50, new DartFinishValues("S10", "D20"));
            DartFinishesList.Add(49, new DartFinishValues("S9", "D20"));
            DartFinishesList.Add(48, new DartFinishValues("S8", "D20"));
            DartFinishesList.Add(47, new DartFinishValues("S15", "D16"));
            DartFinishesList.Add(46, new DartFinishValues("S14", "D16"));
            DartFinishesList.Add(45, new DartFinishValues("S13", "D16"));
            DartFinishesList.Add(44, new DartFinishValues("S12", "D16"));
            DartFinishesList.Add(43, new DartFinishValues("S11", "D16"));
            DartFinishesList.Add(42, new DartFinishValues("S10", "D16"));
            DartFinishesList.Add(41, new DartFinishValues("S9", "D16"));
            DartFinishesList.Add(39, new DartFinishValues("S7", "D16"));
            DartFinishesList.Add(37, new DartFinishValues("S5", "D16"));
            DartFinishesList.Add(35, new DartFinishValues("S3", "D16"));
            DartFinishesList.Add(33, new DartFinishValues("S1", "D16"));
            DartFinishesList.Add(31, new DartFinishValues("S7", "D12"));
            DartFinishesList.Add(29, new DartFinishValues("S13", "D8"));
            DartFinishesList.Add(27, new DartFinishValues("S11", "D8"));
            DartFinishesList.Add(25, new DartFinishValues("S9", "D8"));
            DartFinishesList.Add(23, new DartFinishValues("S7", "D8"));
            DartFinishesList.Add(21, new DartFinishValues("S5", "D8"));
            DartFinishesList.Add(19, new DartFinishValues("S3", "D8"));
            DartFinishesList.Add(17, new DartFinishValues("S13", "D2"));
            DartFinishesList.Add(15, new DartFinishValues("S7", "D4"));
            DartFinishesList.Add(13, new DartFinishValues("S5", "D4"));
            DartFinishesList.Add(11, new DartFinishValues("S3", "D4"));
            DartFinishesList.Add(9, new DartFinishValues("S1", "D4"));
            DartFinishesList.Add(7, new DartFinishValues("S3", "D2"));
            DartFinishesList.Add(5, new DartFinishValues("S1", "D2"));
            DartFinishesList.Add(3, new DartFinishValues("S1", "D1"));
        }

        #endregion
    }

    public class DartFinishValues
    {
        public string Dart1;
        public string Dart2;
        public string Dart3;

        public DartFinishValues(string x, string y, string z = "")
        {
            Dart1 = x;
            Dart2 = y;
            Dart3 = z;
        }
    }
}
