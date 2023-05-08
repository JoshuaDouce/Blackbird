namespace Blackbird.RazorComponents.States
{
    public class BasketState
    {
        public event Action OnChange;
        private int _basketItemCount;

        public int BasketItemCount
        {
            get => _basketItemCount;
            private set
            {
                _basketItemCount = value;
                NotifyStateChanged();
            }
        }

        public void IncrementBasketItemCount()
        {
            BasketItemCount++;
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
