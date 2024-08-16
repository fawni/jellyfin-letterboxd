_default:
    @just --list

@build:
    dotnet build -c Release

@install: (build)
    mkdir -p /var/lib/jellyfin/plugins/Letterbox_1.0.0
    sudo cp -u Letterboxd/bin/Release/net6.0/Letterboxd.dll /var/lib/jellyfin/plugins/Letterbox_1.0.0

retag:
    git tag -d v1.0.0
    git push -d origin v1.0.0
    git tag v1.0.0
    git push origin v1.0.0
