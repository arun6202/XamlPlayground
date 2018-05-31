SECONDS=0;
msbuild /p:Configuration=Clean /verbosity:minimal $HOME/UserInterfaceBuilder/UserInterfaceBuilderPreserver/UserInterfaceBuilderPreserver.csproj ; msbuild /t:restore /verbosity:minimal  $HOME/UserInterfaceBuilder/UserInterfaceBuilderPreserver/UserInterfaceBuilderPreserver.csproj ; msbuild /p:Configuration=Build /verbosity:minimal $HOME/UserInterfaceBuilder/UserInterfaceBuilderPreserver/UserInterfaceBuilderPreserver.csproj ; "/usr/local/share/dotnet/dotnet"  $HOME/UserInterfaceBuilder/UserInterfaceBuilderPreserver/bin/Build/netcoreapp2.1/UserInterfaceBuilderPreserver.dll;
echo :"Time taken to execute: $((($SECONDS / 60) % 60))min $(($SECONDS % 60))sec"

#Open terminal and run this : sh $HOME/XamlPlayground/XamlPlayground/References/postbuild.sh