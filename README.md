# Étterem Webapi
Egy egszerű asztalfoglalásmenedzsment backend.

## Futtatás

A szerver indítása lehetséges a mellékelt `run.sh` bash script hasnálatával, valamint a `dotnet run` parancs futtatásával a `HTML5-CSS_Course_Backend_Endpoint` könyvtárban.

>Amennyiben nem a `dotnet run` parancs nem fut le sikeresen, mivel a **framework nem találhetó**, a `dotnet run --roll-forward LatestMajor` parancs alkalmazásával a hiba javítható.

Az api elérhető a parancsoron jelzett domain-en (alapértelmezetten localhost) és port-on. A **swagger UI** csak <span style="color:yellow">Debug módban</span> (`dotnet run` -al) elérhető a `http://{domain}:{port}/swagger/index.html` oldalon

## Kiadás

A mellékelt `pack.sh` bash script, vagy az abban található parancs a projekt gyökérkönyvtátából futtatásával egy önálló exe generálható, amely önmagában futtatható. Az így létrehozott program a `HTML5_CSS_Course_Backend_Endpoint/bin/Release/{dotnet verzió}/{operációs rendszer}/publish/` könyvtárban lesz található.
