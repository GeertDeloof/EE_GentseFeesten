using DomainController.Model;

namespace TestOverlap
{
    public class UnitTestOverlap
    {
        [Theory]
        [InlineData(0,0,true)]  // totale duur 45'
        [InlineData(+15, 0, true)]
        [InlineData(+45, 0, true)]
        [InlineData(46, 46, false)]
        [InlineData(-15, -15, true)]
        [InlineData(-45, -45, true)]
        [InlineData(-46, -46, false)]

        public void EvenementOverlapt(int x, int y, bool verwachtResultaat)
        {

            #region Arrange
            string lijn1 = "000cee29-43a2-4425-8321-07b7c7f7b51f;17-07-2022 13:45;17-07-2022 13:00;" +
                "29514079-b3db-d844-2019-000000002874;;" +
                "Pastoor Guy Claus zal samen met enkele confraters de mis van zondag 17 juli opdragen in het Gents. Vrie welgekomen !;" +
                "Mis in 't Gentsch gesproken;5;";
            Evenement ev1 = new Evenement(lijn1);  // 		Key	"00695927-ef9a-a1ca-4813-000000002385"	string
                                                   //ev1.EindDatumEnUur = ev1.StartDatumEnUur.AddMinutes(45);
            string lijn2 = "000cee29-43a2-4425-8321-07b7c7f7b51f;17-07-2022 13:45;17-07-2022 13:00;" +
                "29514079-b3db-d844-2019-000000002874;;" +
                "Pastoor Guy Claus zal samen met enkele confraters de mis van zondag 17 juli opdragen in het Gents. Vrie welgekomen !;" +
                "Mis in 't Gentsch gesproken;5;";
            Evenement ev2 = new Evenement(lijn2);
            #endregion
            #region Act
            ev2.StartDatumEnUur = ev2.StartDatumEnUur.AddMinutes(x);
            ev2.EindDatumEnUur = ev2.EindDatumEnUur.AddMinutes(y);
            #endregion
            #region Assert
            Assert.Equal (verwachtResultaat, ev1.OverlaptMet(ev2));
            #endregion

        }
    }
}