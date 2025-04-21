## **Architecture Overview**

The container system provides a comprehensive solution for managing in-game items, including:

- Item storage and manipulation
- Visual representation of contents
- Player interaction with containers
- Integration with the inventory system

## **Core Components**

### **1. Container System**

### **ContainerFactory**

Factory for creating different container types.

### **ContainerModel**

- Manages container state
- Handles item add/remove logic
- Provides access to container data

### **ContainerView**

- Visual representation of containers in the game world
- Handles player interaction

### **EContainerType**

Enumeration of container types:

- Bookshelf
- Barrel
- Chest, etc.

### **2. Specialized Implementations**

### **BookshelfView**

Custom view for bookshelves

### **ShelfItem**

Shelf item with additional parameters

### **EShelfItemType**

Shelf item types:

- Books
- Other items

### **ContainersView/Presenter/Model**

Parent component for managing all scene containers

---

## **Data System**

### **IRepository**

Interface for data storage operations

### **Repository (Abstract Class)**

Base repository implementation

### **InventoryRepository**

Handles inventory data

### **ContainersRepository**

Manages container data

### **DataPresenter**

Mediator between repositories and views

---

## **Item System**

### **Type Enums:**

- **`EItemType`** – Base item types
- **`EArmorType`** – Armor types
- **`EBookType`** – Book types
- **`EEquipmentClass`** – Equipment classes
- **`EFoodType`** – Food types
- **`EPlayerStat`** – Player stats (for potions)
- **`EPotionType`** – Potion types
- **`EWeaponClass`** – Weapon classes
- **`EArmorClass`** – Armor classes

### **Item Factories:**

- **`AccessoriesFactory`** – Accessories
- **`ArmorFactory`** – Armor
- **`BooksFactory`** – Books
- **`FoodFactory`** – Food
- Other specialized factories

### **Item Configurations**

Base **`ItemConfig`** and specialized configs per item type

### **ItemDatabase**

Centralized storage for all item configs

---

## **Localization**

### **LocalizationPresenter/Model**

Manages UI localization

### **ELanguage**

Supported languages

### **ELocalizationRegion**

Translation contexts:

- Item types
- Item names
- UI element text, etc.

---

## **Player & Interaction**

### **Player Components:**

- **`PlayerView/Presenter`** – Core components
- **`PlayerStats`** – Stat management
- **`PlayerLocomotion`** – Movement control
- **`PlayerInteraction`** – Interaction handling

### **IInteractable**

Interface for interactive objects

---

## **User Interface**

### **Base Components:**

- **`UIView/UIModel`** – Core UI classes
- Reactive views (**`UIReactiveView`** and derivatives)

### **Container UI:**

- **`ContainerUIModel/Presenter/View`**
- Controls (filtering, sorting)
- Item display (**`ItemUIView`**)

### **Auxiliary Elements:**

- Cursor
- Interaction prompts
- Main menu
- Language switcher

---

## **Development Tools**

### **RepositoriesTool**

Editor tool for repository management

### **IDGenerator**

Utility for generating unique IDs

---

## **Dependency Injection**

### **GameLifetimeScope**

Dependency setup via **VContainer**

---

## **Workflow**

1. **Container Creation**:
    - Model and view initialization
    - Registration in **`ContainersRepository`**
2. **Interaction**:
    - Player approaches a container
    - Interaction system detects container (**`IInteractable`**)
    - UI opens on command
    - **If previously opened**: Loads cached contents
    - **If new**: **`ContainerFactory`** generates contents
3. **Item Management**:
    - All operations via **`ContainerModel`**
    - Changes sync with UI
    - Validation checks (capacity, weight, etc.)
4. **Localization**:
    - Texts loaded from JSON
    - Updated via **`LocalizationPresenter`**

---

## **Key Features**

✅ **Reactive UI**

- Auto-updates via data binding
- View-model synchronization

✅ **Flexible Filtering/Sorting**

- Multiple filter criteria
- Extensible architecture

✅ **Inventory Integration**

- Unified item handling
- Drag-and-drop between containers/inventory

---

## **Version: 1.0.0**

---

### **Last Updated: 2023-11-15**
