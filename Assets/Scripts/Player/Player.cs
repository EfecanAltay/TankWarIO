public class Player : Live
{
    public string Name;
    public delegate void TakeEnergyEvent();
    public event TakeEnergyEvent TakeEnergyCallBack;
    bool isEneryTaked = false;
    public float EnergyTimer = 0f;
    public Player()
    {
       
    }

    public bool TakeEnergy()
    {
        if (!isEneryTaked)
        {
         if(TakeEnergyCallBack != null) TakeEnergyCallBack();
         return true;
        }
        return false;
    }
}
