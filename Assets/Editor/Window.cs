using System.Collections;
using UnityEditor;
using UnityEngine;

public class Window : EditorWindow
{
    public MeshRenderer GO;
    public Color myColor;

    [MenuItem("Редактировать / Куб")]
    public static void ShowWindow()
    {
        GetWindow(typeof(Window), false, "Окно редактирования");
    }
    void OnGUI()
    {
        GO = EditorGUILayout.ObjectField("Mesh obj", GO, typeof(MeshRenderer), true) as MeshRenderer;
        if (GO)
        {
            myColor = RGBSlider(new Rect(10, 50, 200, 20), myColor);
            GO.sharedMaterial.color = myColor; // Покраска объекта
        }
    }
    float LabelSlider(Rect screenRect, float sliderValue, float sliderMinValue, float sliderMaxValue, string labelText)
    {
        // создаём прямоугольник с координатами в пространстве и заданой шириной и высотой 
        Rect labelRect = new Rect(screenRect.x, screenRect.y, screenRect.width / 2, screenRect.height);

        GUI.Label(labelRect, labelText);   // создаём Label на экране

        Rect sliderRect = new Rect(screenRect.x + screenRect.width / 2, screenRect.y, screenRect.width / 2, screenRect.height); // Задаём размеры слайдера
        sliderValue = GUI.HorizontalSlider(sliderRect, sliderValue, sliderMinValue, sliderMaxValue); // Вырисовываем слайдер и считываем его параметр
        return sliderValue; // Возвращаем значение слайдера
    }

    // Отрисовка тройной слайдер группы, каждый слайдер отвечает за свой цвет
    Color RGBSlider(Rect screenRect, Color rgb)
    {
        // Используя пользовательский слайдер, создаём его
        rgb.r = LabelSlider(screenRect, rgb.r, 0.0f, 1.0f, "Red");

        // делаем промежуток
        screenRect.y += 20;
        rgb.g = LabelSlider(screenRect, rgb.g, 0.0f, 1.0f, "Green");

        screenRect.y += 20;
        rgb.b = LabelSlider(screenRect, rgb.b, 0.0f, 1.0f, "Blue");

        screenRect.y += 20;
        rgb.a = LabelSlider(screenRect, rgb.a, 0.0f, 1.0f, "alpha");

        return rgb; // возвращаем цвет
    }
}
