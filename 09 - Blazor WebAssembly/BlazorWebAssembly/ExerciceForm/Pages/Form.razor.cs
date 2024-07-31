using ExerciceForm.Models;

namespace ExerciceForm.Pages
{
    public partial class Form
    {
        public Person Person { get; set; } = new Person() { BirthDate = DateTime.Now.AddYears(-18)};
        public bool ShowResult { get; set; } = false;
        public void Submit()
        {
            ShowResult = true;
        }
    }
}
