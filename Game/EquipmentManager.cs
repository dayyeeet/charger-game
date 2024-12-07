using Raylib_cs;
using System.Collections.Generic;
using System.Linq;

namespace Game
{
    public class EquipmentManager
    {
        private const KeyboardKey CycleKeyBind = KeyboardKey.K;
        private int _currentIndex = 0;

        public List<Item> Inventory { get; private set; }
        public Item? CurrentItem { get; private set; }

        private readonly ItemManager _itemManager;

        public EquipmentManager(ItemManager itemManager)
        {
            _itemManager = itemManager;
            Inventory =
            [
                new PlaceholderItem(),
                new PlaceholderItem2(),
                new SpoonItem(),
                new GunItem("laser-gun", new LaserGun()),
                new PlasmaGunItem(),
                new ChainsawItem()
            ];

            CurrentItem = Inventory.Any() ? Inventory[0] : null;
            if (CurrentItem != null)
            {
                _itemManager.SetItem(CurrentItem);
            }
        }

        public void Update()
        {
            if (Raylib.IsKeyPressed(CycleKeyBind))
            {
                CycleInventory();
            }
        }
        private void CycleInventory()
        {
            if (!Inventory.Any()) return;

            _currentIndex = (_currentIndex + 1) % Inventory.Count;
            CurrentItem = Inventory[_currentIndex];

            _itemManager.SetItem(CurrentItem);
        }
    }
}

