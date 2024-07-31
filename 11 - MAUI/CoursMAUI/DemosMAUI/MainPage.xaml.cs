using DemosMAUI.Models;
using DemosMAUI.Views;
using System.Collections.ObjectModel;

namespace DemosMAUI
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        // ObservableCollection est utilisé lorsque
        // l'on veut une mise à jour en temps réel
        public ObservableCollection<TodoItem> TodoList { get; set; }

        public MainPage()
        {
            InitializeComponent();

            // Définir les items sans binding
            // => on devra les ajouter/retirer dans la liste à la main à chaque changements
            //TodoListView.ItemsSource = new List<TodoItem>
            //{
            //	new TodoItem() {Name = "item1", Done = false},
            //	new TodoItem() {Name = "item2", Done = true},
            //	new TodoItem() {Name = "item3", Done = false},
            //	new TodoItem() {Name = "item4", Done = false},
            //	new TodoItem() {Name = "item5", Done = true},
            //};

            // Bases de Binding
            // BindingContext est la propriété centrale pour le Binding, dans le pattern MVVM, on lui assigne le ViewModel
            // ici il est assigné à une liste de type ObservableCollection
            BindingContext = TodoList = new ObservableCollection<TodoItem>
            {
                 new TodoItem() {Name = "item1", Done = false},
                 new TodoItem() {Name = "item2", Done = true},
                 new TodoItem() {Name = "item3", Done = false},
                 new TodoItem() {Name = "item4", Done = false},
                 new TodoItem() {Name = "item5", Done = true},
            };
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            if (sender is Button)
            {
                count++;

                if (count == 1)
                    CounterBtn.Text = $"Clicked {count} time";
                else
                    CounterBtn.Text = $"Clicked {count} times";

                SemanticScreenReader.Announce(CounterBtn.Text);
            }
            else
                LblText.Text = "valeur de l'Entry = " + EtTest.Text;
        }

        public void AddToList(object sender, EventArgs e)
        {
            //var list = BindingContext as ObservableCollection<TodoItem>;
            //list.Add(new TodoItem() { Name = "new", Done = false });
		
            TodoList.Add(new TodoItem() { Name = "new", Done = true });
        }

        private async void GotoPageFullCS(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PageFullCS());

            // ajouter du code ici qui s'exécutera au retour sur la MainPage
        }

        private async void GotoPushPopPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PushPopPage("Valeur par défaut entry"));
        }
    }

}
