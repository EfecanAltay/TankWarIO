public class Live
{
    public delegate void DeadEvent();
    public delegate void HealthUPDownEvent(float h);

    public event DeadEvent DeadCallback;
    public event HealthUPDownEvent HealthUPCallback;
    public event HealthUPDownEvent HealthDownCallback;

    public float HealthPoint = 100f;
    public float AttackPoint = 10f;
    public float DeffencePoint = 0f;
    public float AttackTime = 2f;

    public float MaxHealthPoint = 100f;


    public bool isDead = false;

    public Live()
    {

    }

    public bool HealUP(float h)
    {
        if (HealthPoint != MaxHealthPoint)
        {
            if (h + HealthPoint < MaxHealthPoint)
            {
                HealthPoint += h;
                if (HealthUPCallback != null) HealthUPCallback(h);
            }
            else
            {
                if (HealthUPCallback != null) HealthUPCallback(MaxHealthPoint);
                HealthPoint = MaxHealthPoint;
            }
            return true;
        }
        else
        {
            return false;
        }
    }
    public float HealDown(float h)
    {
        if (0 < h)
        {
                if (HealthPoint -h  > 0)
                {
                    HealthPoint -= h;
                    if (HealthDownCallback != null) HealthDownCallback(h);
                    return h;
                }
                else
                {
                    HealthPoint = 0;
                    isDead = true;
                    if (DeadCallback != null) DeadCallback();
                    return 0;
                }
         }
        return 0;
    }

    public float Attack(Live liver)
    {
            return liver.HealDown(AttackPoint);
    }
}
