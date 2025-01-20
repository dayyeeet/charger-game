using Raylib_cs;

namespace Game
{
    public class EquipmentManager
    {
        private int _currentIndex;

        public int CurrentIndex => _currentIndex;

        public List<Item?> Items { get; private set; }
        public Item? CurrentItem { get; internal set; }

        public EquipmentManager()
        {
            Items =
            [
                new LaserGunItem(),
                new PlasmaGunItem(),
                new SpoonItem(),
                new ChainsawItem(),
                new MilkBottleItem(),
                null,
                null,
                null,
                null
            ];

            CurrentItem = Items.Count > 0 ? Items[0] : null;
        }

        public void Update()
        {
            var scroll = Raylib.GetMouseWheelMove();
            if (scroll == 0)
            {
                return;
            }

            CycleInventory(scroll > 0);
        }

        public void UpdateEquipped(ItemManager leftHand, ItemManager rightHand)
        {
            if (Raylib.IsKeyPressed(KeyboardKey.Q))
            {
                UpdateEquipped(leftHand);
                return;
            }

            if (Raylib.IsKeyPressed(KeyboardKey.E))
            {
                UpdateEquipped(rightHand);
            }
        }

        private void UpdateEquipped(ItemManager manager)
        {
            var last = manager.Item;
            manager.SetItem(CurrentItem);
            CurrentItem = last;
            Items[_currentIndex] = last;
        }

        public void CycleHotkey()
        {
            var hotkey = Raylib.GetKeyPressed();
            if (hotkey <= 0) return;
            hotkey -= 49;
            if (hotkey >= Items.Count || hotkey < 0) return;
            _currentIndex = hotkey;
            CurrentItem = Items[_currentIndex];
        }

        private void CycleInventory(bool right = true)
        {
            if (Items.Count <= 0) return;

            _currentIndex = (_currentIndex + 1 * (right ? 1 : -1)) % Items.Count;
            if (_currentIndex < 0)
            {
                _currentIndex = Items.Count - 1;
            }

            CurrentItem = Items[_currentIndex];
        }
    }
}