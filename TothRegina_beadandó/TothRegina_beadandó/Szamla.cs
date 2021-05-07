namespace TothRegina_beadandó
{
    /// <summary>
    /// Egy számla adatait leíró osztály
    /// </summary>
    internal class Szamla
    {
        /// <summary>
        /// A számla példány egyenlegét tárolja.
        /// </summary>
        ///<value>
        /// Intet tartalmazó változó
        /// </value>
        public int egyenleg { get; set; }
        /// <summary>
        /// A számla példány tulajdonosának nevét tárolja.
        /// </summary>
        /// <value>
        /// Stringet tartalmazó változó
        /// </value>
        /// 
        public string tulaj { get; set; } = "";

        /// <summary>
        /// Getter, amely vissza adja a számla tulajdonosának a nevét.
        /// </summary>
        /// <value>
        /// Egy stringet ad vissza
        /// </value>
        public string Tulaj
        {
            ///<return>
            ///Vissza adja a számla tulajdonosának a nevét
            ///</return>
            get { return tulaj; }
        }

        /// <summary>
        /// Getter, amely vissza adja a számla egyenlegét.
        /// </summary>
        /// <value>
        /// Egy intet ad vissza
        /// </value>
        public int Egyenleg
        {
            ///<return>
            ///Vissza adja a számla egyenlegét
            ///</return>
            get { return egyenleg; }
        }

        /// <summary>
        /// A konstruktor beállítja a példány egyenlegét és tulajdonosának nevét.
        /// </summary>
        /// <param name="egy">A számla egyenlege</param>
        /// <param name="tul">A számla tulajdonosának neve</param>
        public Szamla(int egy, string tul)
        {
            egyenleg = egy;
            tulaj = tul;
        }

        /// <summary>
        /// Az osztály metódusa amely a kapott értékkel növeli a számla egyenlegét.
        /// </summary>
        /// <param name="x">Az érték amivel növelni kell az egyenleget</param>
        public void Egyenlegno(int x)
        {
            egyenleg = egyenleg + x;
        }

        /// <summary>
        /// Az osztály metódusa amely a kapott értékkel csökkenti a számla egyenlegét.
        /// </summary>
        /// <param name="x">Az érték amivel csökkenteni kell az egyenleget</param>
        public void Egyenlegcsokk(int x)
        {
            
            egyenleg -= x;
        }

        /// <summary>
        /// Az osztály metódusa amely a kapott névre cseréli a számla tulajdonosának a nevét.
        /// </summary>
        /// <param name="n">Az új név</param>
        public void NevValt(string n)
        {
            tulaj = n;
        }
    }
}