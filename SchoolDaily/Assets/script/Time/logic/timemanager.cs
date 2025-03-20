using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timemanager : MonoBehaviour
{
    private int gamesecond,gameminute,gamehour,gameday,gamemonth,gameyear;
    private Season gameseason = Season.春天;//初始赋值
    private int monthinseason = 3;
    public bool gameclockpause;
    private float tiktime;//计时器

    private void Update()
    {
        if(!gameclockpause)
        {
            tiktime += Time.deltaTime;

            if(tiktime >= Settings.secondthreshold)//大于等于设置的阈值
            {
                tiktime -= Settings.secondthreshold;
                Updategametime();
            }

        }
    }

    private void Updategametime()
    {
        gamesecond++;
        if(gamesecond > Settings.secondhold)
        {
            gameminute++;
            gamesecond = 0;

            if(gameminute > Settings.minutehold)
            {
                gamehour++;
                gameminute = 0;

                if(gamehour > Settings.hourhold)
                {
                    gameday++;
                    gamehour = 0;

                    if(gameday > Settings.dayhold)
                    {
                        gamemonth++;
                        gameday = 1;

                        if(gamemonth > 12)
                        gamemonth = 1;

                        monthinseason--;
                        if(monthinseason == 0)
                        {
                            monthinseason = 3;

                            int seasonnumber = (int)gameseason;
                            seasonnumber++;

                            if(seasonnumber > Settings.seasonhold)
                            {
                                seasonnumber = 0;
                                gameyear++;
                            }

                            gameseason = (Season)seasonnumber;

                            if(gameyear > 4)
                            {

                            }
                        }
                    }
                }
            }
        }
            Debug.Log("second"+gamesecond+"minute"+gameminute);
    }
}
