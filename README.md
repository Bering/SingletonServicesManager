# SingletonServicesManager

Allows global access to a single instance of any class.

Based on Eliot Lash's at https://www.packtpub.com/books/content/one-liner-singletons-unity

## Description
It's a Singleton class holding a dictionary of Object instances.

It says "Service" but it's anything inheriting the Object() class really.

## Registering a service
Register an object (usually in the object's Awake())

On a Monobehaviour:

    void Awake()
    {
        Services.Register<GameManager>(this);
    }

Pretty much anywhere:

    Services.Register<Player>(new Player());

## Accessing a service
Simple, as long as you don't do it in Awake():

On a Monobehaviour:

    void Start()
    {
        GameManager GM = Services.Find<GameManager>();
    }

Pretty much anywhere:

    Player localPlayer = Services.Find<Player>();

If you really have to do it in Awake(), it's exactly the same, but you have to make sure that the script registering the service is executed *before* the script that tries to find it.

    __Edit__ > __Projects__ > __Script Execution Order__

