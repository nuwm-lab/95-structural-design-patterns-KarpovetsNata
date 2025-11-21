using System;

// --- Цільовий інтерфейс (Target) ---
interface IJoystick
{
    void MoveUp();
    void MoveDown();
    void MoveLeft();
    void MoveRight();
    void Fire();
}

// --- Старий джойстик (Adaptee) ---
class OldJoystick
{
    public void Up() => Console.WriteLine("OldJoystick: Up");
    public void Down() => Console.WriteLine("OldJoystick: Down");
    public void Left() => Console.WriteLine("OldJoystick: Left");
    public void Right() => Console.WriteLine("OldJoystick: Right");
    public void Shoot() => Console.WriteLine("OldJoystick: Shoot");
}

// --- Новий джойстик (Adaptee) ---
class NewJoystick
{
    public void MoveVertical(int delta)
    {
        if (delta > 0) Console.WriteLine("NewJoystick: Move Up");
        else if (delta < 0) Console.WriteLine("NewJoystick: Move Down");
    }

    public void MoveHorizontal(int delta)
    {
        if (delta > 0) Console.WriteLine("NewJoystick: Move Right");
        else if (delta < 0) Console.WriteLine("NewJoystick: Move Left");
    }

    public void FireButton() => Console.WriteLine("NewJoystick: Fire");
}

// --- Адаптер для старого джойстика ---
class OldJoystickAdapter : IJoystick
{
    private OldJoystick _oldJoystick;

    public OldJoystickAdapter(OldJoystick oldJoystick)
    {
        _oldJoystick = oldJoystick;
    }

    public void MoveUp() => _oldJoystick.Up();
    public void MoveDown() => _oldJoystick.Down();
    public void MoveLeft() => _oldJoystick.Left();
    public void MoveRight() => _oldJoystick.Right();
    public void Fire() => _oldJoystick.Shoot();
}

// --- Адаптер для нового джойстика ---
class NewJoystickAdapter : IJoystick
{
    private NewJoystick _newJoystick;

    public NewJoystickAdapter(NewJoystick newJoystick)
    {
        _newJoystick = newJoystick;
    }

    public void MoveUp() => _newJoystick.MoveVertical(1);
    public void MoveDown() => _newJoystick.MoveVertical(-1);
    public void MoveLeft() => _newJoystick.MoveHorizontal(-1);
    public void MoveRight() => _newJoystick.MoveHorizontal(1);
    public void Fire() => _newJoystick.FireButton();
}

// --- Клієнт ---
class Program
{
    static void Main()
    {
        IJoystick oldJs = new OldJoystickAdapter(new OldJoystick());
        IJoystick newJs = new NewJoystickAdapter(new NewJoystick());

        Console.WriteLine("Використання старого джойстика через адаптер:");
        oldJs.MoveUp();
        oldJs.MoveRight();
        oldJs.Fire();

        Console.WriteLine("\nВикористання нового джойстика через адаптер:");
        newJs.MoveDown();
        newJs.MoveLeft();
        newJs.Fire();
    }
}
