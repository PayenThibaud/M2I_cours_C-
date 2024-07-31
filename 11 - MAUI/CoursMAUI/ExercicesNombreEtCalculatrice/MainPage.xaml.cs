namespace ExercicesNombreEtCalculatrice
{
    public partial class MainPage : ContentPage
    {
        #region NbMyst
        //// on initialise le compteur de tentatives au max
        //private static int max = 10;
        //private int count = max;

        //// on définit le nombre mystère
        //private int SecretNb = new Random().Next(1, 101);

        //public MainPage()
        //{
        //    InitializeComponent();
        //}

        //private void OnResetClicked(object sender, EventArgs e)
        //{
        //    // on remet tout à zéro
        //    count = 10;
        //    SecretNb = new Random().Next(1, 101);
        //    ResultLabel.Text = "";
        //    GuessEntry.Text = "";
        //    TryBtn.IsEnabled = true;
        //    ResetBtn.IsVisible = false;
        //}

        //private void OnTryClicked(object sender, EventArgs e)
        //{
        //    // on renvoie une erreur dans le label si l'utilisateur n'a pas entré un nombre
        //    if (!int.TryParse(GuessEntry.Text, out int nb))
        //    {
        //        ResultLabel.Text = "Veuillez entrer un nombre";
        //        // on change la couleur du texte
        //        ResultLabel.TextColor = Colors.Red;
        //        return;
        //    }

        //    // on décrémente le compteur de tentatives
        //    count--;

        //    // on compare le nombre entré par l'utilisateur avec le nombre mystère
        //    if (nb == SecretNb)
        //    {
        //        ResultLabel.Text = $"Bravo ! Vous avez trouvé en {max - count} tentatives !";
        //        ResultLabel.TextColor = Colors.Green;
        //        TryBtn.IsEnabled = false;
        //        ResetBtn.IsVisible = true;
        //    }
        //    else if (count == 0)
        //    {
        //        ResultLabel.Text = $"Vous avez perdu ! Le nombre mystère était {SecretNb}.";
        //        ResultLabel.TextColor = Colors.Red;
        //        TryBtn.IsEnabled = false;
        //        ResetBtn.IsVisible = true;
        //    }
        //    else if (nb < SecretNb)
        //    {
        //        ResultLabel.Text = $"Le nombre mystère est plus grand.\nIl vous reste {count} tentatives.";
        //        ResultLabel.TextColor = Colors.DarkBlue;
        //    }
        //    else
        //    {
        //        ResultLabel.Text = $"Le nombre mystère est plus petit.\nIl vous reste {count} tentatives.";
        //        ResultLabel.TextColor = Colors.BlueViolet;
        //    }
        //}
        #endregion

        public MainPage()
        {
            InitializeComponent();
        }
    }
}
