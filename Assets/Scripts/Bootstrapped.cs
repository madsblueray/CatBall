public interface Bootstrapped
{
    void Initialize();

    int Priority{
        get;
    }
}