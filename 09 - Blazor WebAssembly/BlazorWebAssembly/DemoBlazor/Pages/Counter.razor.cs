using Microsoft.AspNetCore.Components;

namespace DemoBlazor.Pages
{
    public partial class Counter
    //public class CounterBase : ComponentBase
    {
        [Parameter]
        public int CurrentCount { get; set; } = 0;

        private void IncrementCount()
        {
            CurrentCount += 10;
        }

        private void DecrementCount()
        {
            CurrentCount -= 10;
        }
    }
}
