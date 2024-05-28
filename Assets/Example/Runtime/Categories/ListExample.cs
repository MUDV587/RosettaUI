using System.Collections.Generic;
using UnityEngine;

namespace RosettaUI.Example
{
    public class ListExample : MonoBehaviour, IElementCreator
    {
        public int[] intArray = {1, 2, 3};
        public List<int> intList = new() {1, 2, 3};
        
        public SimpleClass[] classArray =
        {
            new() {stringValue = "1"}, 
            new() {stringValue = "2"}, 
            new() {stringValue = "2"}
        };
        
        public List<SimpleClass> classList = new()
        {
            new SimpleClass {stringValue = "1"}, 
            new SimpleClass {stringValue = "2"}, 
            new SimpleClass {stringValue = "2"}
        };

        [NonReorderable]
        public int[] nonReorderableArray = {1,2,3};
        
        public Element CreateElement(LabelElement _)
        {
            var listViewOption = ListViewOption.Default;
            
            return UI.Tabs(
                ExampleTemplate.UIFunctionTab(nameof(UI.List),
                    UI.List(() => intArray),
                    UI.List(() => intList),
                    UI.List(() => classArray),
                    UI.List(() => classList),
                    UI.HelpBox("Right-click on an item to open the menu", HelpBoxType.Info)
                ),
                ExampleTemplate.UIFunctionTab(nameof(UI.ListReadOnly),
                    UI.ListReadOnly(() => intArray),
                    UI.ListReadOnly(() => intList),
                    UI.ListReadOnly(() => classArray),
                    UI.ListReadOnly(() => classList)
                ),
                ExampleTemplate.Tab("Codes",
                    ExampleTemplate.CodeElementSets("CustomItemElement",
                        (@"UI.List(() => intArray,
    createItemElement: (itemBinder, idx) => UI.Row(
        UI.Field($""Item {idx}"", itemBinder),
        UI.Button(""+"", () => intArray[idx]++),
        UI.Button(""-"", () => intArray[idx]--)
);",
                            UI.List(() => intArray,
                               createItemElement: (itemBinder, idx) => UI.Row(
                                    UI.Field($"Item {idx}", itemBinder),
                                    UI.Button("+", () => intArray[idx]++),
                                    UI.Button("-", () => intArray[idx]--)
                                )
                            )
                        )
                    ),
                    ExampleTemplate.CodeElementSets("Options",
                        (@"var listViewOption = ListViewOption.Default;

UI.Field(() => listViewOption).Open(),
UI.DynamicElementOnStatusChanged(
    () => listViewOption,
    _ => UI.List(() => intArray, listViewOption)
)",
                            UI.Column(
                                UI.Field(() => listViewOption).Open(),
                                UI.DynamicElementOnStatusChanged(
                                    () => listViewOption,
                                    _ => UI.List(() => intArray, listViewOption)
                                )
                            )
                        )
                    ),
                    ExampleTemplate.CodeElementSets("<b>Attribute</b>",
                        (@"[NonReorderable]
public int[] nonReorderableArray;

UI.List(() => nonReorderableArray);
",
                            UI.List(() => nonReorderableArray)))
                )
            );
        }
    }
}