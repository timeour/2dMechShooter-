#pragma strict

function Start () {

}

public var welcomeLabel : GUIStyle;
public var customSkin : GUISkin;
public var playGameRect : Rect;
public var optionsRect : Rect;
public var quitRect : Rect;


private var optionsMode = false;

public var _bulletImpulse : float = 300;
public var _shootDelay : float = 1;

function OnGUI(){
    if(!optionsMode){
        GUI.Label(new Rect(Screen.width / 2, 0, 50, 20),"Welcome",welcomeLabel);

        GUI.skin = customSkin;

        if(GUI.Button(playGameRect,"Play Game")){
            Application.LoadLevel("game3");  //1
        }
           
        if(GUI.Button(optionsRect,"Options")){
            optionsMode = true;
        }
                   
        if(GUI.Button(quitRect,"Quit")){
            Application.Quit();                   //2
        }
                   
    }else{
                                           
        GUI.Label(new Rect(Screen.width / 2, 0, 50, 20), "Options",welcomeLabel);
                   
        GUI.skin = customSkin;
                   
        GUI.Label(new Rect(270, 75, 50, 20),"Bullet Impulse");
        _bulletImpulse = GUI.HorizontalSlider(new Rect(50, 100, 500, 20),_bulletImpulse,10,700);
        GUI.Label(new Rect(560, 95, 50, 20),_bulletImpulse.ToString());
           
        GUI.Label(new Rect(270, 125, 50, 20),"Shoot Delay");
        _shootDelay = GUI.HorizontalSlider(new Rect(50, 150, 500, 20),_shootDelay,0.1,3);
        GUI.Label(new Rect(560, 145, 50, 20),_shootDelay.ToString());
                   
        if(GUI.Button(new Rect(20, 190, 100, 30),"<< Back")){
            optionsMode = false;
        }
           
    }  
                           
}