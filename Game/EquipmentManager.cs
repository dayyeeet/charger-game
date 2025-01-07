using Raylib_cs;
using System.Collections.Generic;
using System.Linq;

namespace Game
{
    public class EquipmentManager
    {
        private int _currentIndex = 0;

        public List<Item> Items { get; private set; }
        public Item? CurrentItem { get; private set; }

        private readonly ItemManager _itemManager;

        public EquipmentManager(ItemManager itemManager)
        {
            _itemManager = itemManager;
            Items =
            [
                new LaserGunItem(),
                new PlasmaGunItem(),
                new SpoonItem(),
                new ChainsawItem(),
                new MilkBottleItem()
            ];

            CurrentItem = Items.Any() ? Items[0] : null;
            if (CurrentItem != null)
            {
                _itemManager.SetItem(CurrentItem);
            }
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
        private void CycleInventory(bool right = true)
        {
            if (!Items.Any()) return;

            _currentIndex = (_currentIndex + 1 * (right? 1: -1)) % Items.Count;
            if (_currentIndex < 0)
            {
                _currentIndex = Items.Count - 1;
            }

            CurrentItem = Items[_currentIndex];
        }
    }
}

