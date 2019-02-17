MAIN_FILE = [Source]/Cosmotoad/bin/Debug/Cosmotoad
SOURCE_DIR = [Source]/Cosmotoad/
CSHARP_SOURCE_FILES = $(wildcard $(SOURCE_DIR)*.cs */*.cs)
# CSHARP_SWITCHES
CSHARP_PROJECT = $(SOURCE_DIR)/Cosmotoad.csproj
CSHARP_COMPILER = MSBuild.exe
EXCECUTABLE = $(MAIN_FILE).exe

$(EXCECUTABLE): $(CSHARP_SOURCE_FILES)
  @ $(CSHARP_COMPILER) $(CSHARP_PROJECT)
  @ echo Build Started...
