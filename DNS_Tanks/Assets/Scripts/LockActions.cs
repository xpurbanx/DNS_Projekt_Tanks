using System.Runtime.CompilerServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[assembly: InternalsVisibleTo("PlayerRotateTurret")]
[assembly: InternalsVisibleTo("PlayerInputSetup")]
[assembly: InternalsVisibleTo("PlayerMovement")]
[assembly: InternalsVisibleTo("PlayerFiring")]
[assembly: InternalsVisibleTo("PlayerButtons")]
[assembly: InternalsVisibleTo("SuppliesAvailable")]
[assembly: InternalsVisibleTo("OverlayEnable")]
[assembly: InternalsVisibleTo("VehSwitchAvailable")]
[assembly: InternalsVisibleTo("CamFollow")]

public class LockActions : MonoBehaviour
{
    // Zmienne przechowywające informacje o wyłączonych funkcjach, nie inpucie
    internal bool movementLocked, aimingLocked, shootingLocked, menusLocked, mapLocked, allLocked;

    // Zmienne przechowywające informacje o całkowicie wyłączonym inpucie
    internal bool movementLOCKED, aimingLOCKED, shootingLOCKED, menusLOCKED, allLOCKED;

    // NIE USTAWIONO (!!!):

    // movementLOCKED, aimingLOCKED, allLOCKED;
}


