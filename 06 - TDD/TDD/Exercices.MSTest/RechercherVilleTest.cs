using Exercices.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercices.MSTest
{
    [TestClass]
    public class RechercherVilleTest
    {
        private RechercheVille _rechercheVille = new RechercheVille(new List<string>() {
            "Paris", "Budapest", "Skopje", "Rotterdam", "Valence", "Vancouver", "Amsterdam", "Vienne" });

        [TestMethod]
        public void RechercherTestWhenLess_2_Char_Raise_NotFoundException()
        {
            Assert.ThrowsException<NotFoundException>(() => _rechercheVille.Rechercher("a"));
        }

        [TestMethod]
        public void RechercherTestWhenGt_2_Char_Return_Cities_Started_With_Char()
        {
            List<string> result = _rechercheVille.Rechercher("Va");

            CollectionAssert.AreEqual(new List<string>() { "Valence", "Vancouver" }, result);
        }
        [TestMethod]
        public void RechercherTestWhenGt_No_Case_Sensitive()
        {
            List<string> result = _rechercheVille.Rechercher("vA");

            CollectionAssert.AreEqual(new List<string>() { "Valence", "Vancouver" }, result);
        }

        [TestMethod]
        public void RechercherTestWhenGt_2_Char_Return_Cities_Contains_With_Char()
        {
            List<string> result = _rechercheVille.Rechercher("ape");

            CollectionAssert.AreEqual(new List<string>() { "Budapest" }, result);
        }

        [TestMethod]
        public void RechercherTestWhen_Char_Asterisk_Return_All_Cities()
        {
            List<string> result = _rechercheVille.Rechercher("*");

            CollectionAssert.AreEqual(new List<string>() { "Paris", "Budapest", "Skopje", "Rotterdam", "Valence", "Vancouver", "Amsterdam", "Vienne" }, result);
        }
    }
}
