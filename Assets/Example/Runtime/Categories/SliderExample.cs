using UnityEngine;

namespace RosettaUI.Example
{
    public class SliderExample : MonoBehaviour, IElementCreator
    {
        public int intValue;
        public uint uintValue;
        public float floatValue;
        public Vector2 vector2Value;
        public Vector3 vector3Value;
        public Vector4 vector4Value;
        public Vector2Int vector2IntValue;
        public Vector3Int vector3IntValue;
        public Rect rectValue;
        public RectInt rectIntValue;
        public RectOffset rectOffsetValue;
        public Bounds boundsValue;
        public BoundsInt boundsIntValue;
        public SimpleClass simpleClass;
        
        [Range(0f, 100f)] 
        public float rangeFloat;
        
        public string stringValue;

        public Element CreateElement(LabelElement _)
        {
            var sliderOption = new SliderOption()
            {
                showInputField = false,
                fieldOption = FieldOption.Default
            };
            
            return UI.Tabs(
                ExampleTemplate.UIFunctionTab(nameof(UI.Slider),
                    UI.Slider(() => intValue),
                    UI.Slider(() => uintValue),
                    UI.Slider(() => floatValue),
                    UI.Slider(() => vector2Value),
                    UI.Slider(() => vector3Value),
                    UI.Slider(() => vector4Value),
                    UI.Slider(() => vector2IntValue),
                    UI.Slider(() => vector3IntValue),
                    UI.Slider(() => rectValue),
                    UI.Slider(() => rectIntValue),
                    UI.Slider(() => rectOffsetValue),
                    UI.Slider(() => boundsValue),
                    UI.Slider(() => boundsIntValue),
                    UI.Slider(() => simpleClass)
                ),
                ExampleTemplate.UIFunctionTab(nameof(UI.SliderReadOnly),
                    UI.SliderReadOnly(() => intValue),
                    UI.SliderReadOnly(() => uintValue),
                    UI.SliderReadOnly(() => floatValue),
                    UI.SliderReadOnly(() => vector2Value),
                    UI.SliderReadOnly(() => vector3Value),
                    UI.SliderReadOnly(() => vector4Value),
                    UI.SliderReadOnly(() => vector2IntValue),
                    UI.SliderReadOnly(() => vector3IntValue),
                    UI.SliderReadOnly(() => rectValue),
                    UI.SliderReadOnly(() => rectIntValue),
                    UI.SliderReadOnly(() => rectOffsetValue),
                    UI.SliderReadOnly(() => boundsValue),
                    UI.SliderReadOnly(() => boundsIntValue),
                    UI.SliderReadOnly(() => simpleClass)
                ),
                ExampleTemplate.Tab("Codes",
                    ExampleTemplate.CodeElementSets("MinMax",
                        ("UI.Slider(() => floatValue, max: 2f);\n",
                            UI.Slider(() => floatValue, max: 2f)),
                        ("UI.Slider(() => floatValue, min: 0.5f, max: 2f);\n",
                            UI.Slider(() => floatValue, min: 0.5f, max: 2f)),
                        (@"UI.Slider(
    () => vector2Value,
    max: Vector2.one * 2f
).Open();
",
                            UI.Slider(
                                () => vector2Value,
                                max: Vector2.one * 2f
                            ).Open()
                        ),
                        (@"UI.Slider(
    () => vector2Value, 
    min: Vector2.one * 0.5f,
    max: Vector2.one * 2f
).Open();
",
                            UI.Slider(
                                () => vector2Value,
                                min: Vector2.one * 0.5f,
                                max: Vector2.one * 2f
                            ).Open()
                        )
                    ),
                    ExampleTemplate.CodeElementSets("Option",
                        (@"var sliderOption = new SliderOption()
{
    showInputField = false,
    fieldOption = FieldOption.Default
};

UI.Field(() => sliderOption).Open();
                            
UI.DynamicElementOnStatusChanged(
    () => sliderOption,
    _ => UI.Slider(() => floatValue, sliderOption)
        .RegisterValueChangeCallback(() => Debug.Log($""OnValueChanged[{floatValue}]""))
)",
                            UI.Column(
                                UI.Field(() => sliderOption).Open(),
                                UI.DynamicElementOnStatusChanged(
                                    () => sliderOption,
                                    _ => UI.Slider(() => floatValue, sliderOption)
                                        .RegisterValueChangeCallback(() => Debug.Log($"OnValueChanged[{floatValue}]"))
                                )
                            )
                        )
                    ),
                    ExampleTemplate.CodeElementSets("Attribute", 
                        (@"[Range(0f, 100f)] 
public float rangeFloat;

UI.Slider(() => rangeFloat);
",
                            UI.Slider(() => rangeFloat)
                        )),
                    ExampleTemplate.CodeElementSets("Unsupported types",
                        "Unsupported types will fall back to UI.Field()", 
                        ("UI.Slider(() => stringValue);\n", UI.Slider(() => stringValue)))
                )
            );
        }
    }
}