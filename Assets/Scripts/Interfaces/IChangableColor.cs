using static ColorData;

interface IChangableColor
{
    void SetColor(BoxColor targetBoxColor);

    void SetColor(BoxColor targetBoxColor, float duration);
}