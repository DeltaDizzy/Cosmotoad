EXECUTABLE = [Source]/Cosmotoad/bin/Debug/Cosmotoad.exe
SOURCE_DIR = [Source]/Cosmotoad
SOURCE_FILES = $(SOURCE_DIR/*/*.cs)
CSC = MSBuild.exe
FRAMEWORK = v4.6.2

Release: $(SOURCE_FILES)
  $(CSC) $(SOURCE_DIR/Cosmotoad.sln) /t:Build /p:Configuration=Release /p:TargetFramework=$(FRAMEWORK)
  @echo Build Started...
