using UnityEngine;
/*
Formalize the observer pattern by forcing classes that implement this interface
implement methods to subscribe to Rampage mode event and a variable to track
if player is on a rampage
*/
public interface IRampageObserver
{
    bool RampageActive { get; set; } 
    void HandleRampageModeChanged(bool isActive);
}
