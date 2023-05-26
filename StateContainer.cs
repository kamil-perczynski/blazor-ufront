public class StateContainer
{
    private State savedState = new State();

    public State State
    {
        get => savedState;
        set
        {
            savedState = value;
            NotifyStateChanged();
        }
    }

    public event Action? OnChange;

    private void NotifyStateChanged() => OnChange?.Invoke();
}

public class State
{

    public int boo { get; set; } = 0;
    public string foo { get; set; } = "";
    public User user { get; set; } = new User();

    public override bool Equals(object? obj)
    {
        return obj is State state &&
               boo == state.boo &&
               foo == state.foo &&
               EqualityComparer<User>.Default.Equals(user, state.user);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(boo, foo, user);
    }

    public State ShallowCopy()
    {
        return new State
        {
            boo = this.boo,
            foo = this.foo,
            user = this.user
        };
    }


}

public class User
{

    public string username { get; set; } = "none";
    public string preferredLanguage { get; set; } = "none";
    public List<string> permissions { get; set; } = new List<string>();

    public override bool Equals(object? obj)
    {
        return obj is User user &&
               username == user.username &&
               preferredLanguage == user.preferredLanguage &&
               Enumerable.SequenceEqual(permissions, user.permissions);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(username, preferredLanguage, permissions);
    }

    public User ShallowCopy()
    {
        return new User
        {
            username = this.username,
            preferredLanguage = this.preferredLanguage,
            permissions = new(this.permissions)
        };
    }

}