#!/usr/bin/env bash

echo "Logging in..."
appcenter login --token "f1d882f81531704405a1e62ea3612e8063491608"

UITestDLL=`find .. -name "GabDemo.Tests.dll" | grep bin | head -1`
UITestBuildDir=`dirname $UITestDLL`
APKFile=`find .. -name *.apk | head -1`

echo "UITest dll: $UITestDLL"
echo "UITest build dir: $UITestBuildDir"
echo "APK file path: $APKFile"

echo "Launching tests..."

appcenter test run uitest --app "matteot/GAB-2018" \
    --devices "matteot/top-selling" \
    --app-path "$APPCENTER_SOURCE_DIRECTORY/Droid/bin/Release/matteotumiati.GabDemo-Signed.apk" \
    --test-series "ui-tests" \
    --locale "en_US" \
    --build-dir "$APPCENTER_SOURCE_DIRECTORY/GabDemo.Tests/bin/Release/" \
    --async

echo "Current branch is $APPCENTER_BRANCH"