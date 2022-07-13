# XamarinMacFileProviderExample
A demo app to use Apple's File Provider framework to access Mac OS file system using Xamarin.Mac libraries


## Issues
When I run the application and the File Provider Extension is loaded, it is unable to communicated with the File Provider UI Extension appex file.

Steps to reproduce
- Run the application
- A new Cloud Storage will be added to the list
- Go to the location
- The folder should be empty(.trash folder will be visible if you've turned ON show hidden files)
- Sign in button should be visible on the top right side of the window
- Upon clicking on the sign in button, expectation is to trigger the `prepare` method in `FPUIActionExtensionViewController` class. In this example it is `DocumentActionViewController`. But the trigger fails with the following error in the console

```
FP Custom action sheet finished with error Error Domain=com.apple.ViewBridge Code=14 "(null)" UserInfo={com.apple.ViewBridge.error.hint={
    callStackSymbols =     (
        "0   CoreFoundation                      __exceptionPreprocess + 242",
        "1   libobjc.A.dylib                     objc_exception_throw + 48",
        "2   Foundation                          -[NSAssertionHandler handleFailureInMethod:object:file:lineNumber:description:] + 267",
        "3   FileProviderUI                      -[FPUIActionExtensionContainerViewController _configureWithDomainIdentifier:] + 170",
        "4   FileProviderUI                      -[FPUIActionExtensionContainerViewController awakeFromRemoteView] + 851",
        "5   ViewBridge                          -[NSViewServiceMarshal _bootstrap:replyData:completion:] + 2235",
        "6   ViewBridge                          -[NSViewServiceMarshal bootstrap:withReply:] + 245",
        "7   CoreFoundation                      __invoking___ + 140",
        "8   CoreFoundation                      -[NSInvocation invoke] + 305",
        "9   CoreFoundation                      -[NSInvocation invokeWithTarget:] + 70",
        "10  ViewBridge                          -[NSVB_ViewServiceImplicitAnimationDecodingProxy forwardInvocation:] + 85",
        "11  CoreFoundation                      ___forwarding___ + 751",
        "12  CoreFoundation                      _CF_forwarding_prep_0 + 120",
        "13  CoreFoundation                      __invoking___ + 140",
        "14  CoreFoundation                      -[NSInvocation invoke] + 305",
        "15  CoreFoundation                      -[NSInvocation invokeWithTarget:] + 70",
        "16  ViewBridge                          -[NSVB_QueueingProxy forwardInvocation:] + 321",
        "17  CoreFoundation                      ___forwarding___ + 751",
        "18  CoreFoundation                      _CF_forwarding_prep_0 + 120",
        "19  CoreFoundation                      __invoking___ + 140",
        "20  CoreFoundation                      -[NSInvocation invoke] + 305",
        "21  CoreFoundation                      -[NSInvocation invokeWithTarget:] + 70",
        "22  CoreFoundation                      ___forwarding___ + 751",
        "23  CoreFoundation                      _CF_forwarding_prep_0 + 120",
        "24  CoreFoundation                      __invoking___ + 140",
        "25  CoreFoundation                      -[NSInvocation invoke] + 305",
        "26  ViewBridge                          __deferNSXPCInvocationOntoMainThread_block_invoke + 228",
        "27  ViewBridge                          __wrapBlockWithVoucher_block_invoke + 37",
        "28  ViewBridge                          __deferBlockOntoMainThread_block_invoke_2 + 274",
        "29  CoreFoundation                      __CFRUNLOOP_IS_CALLING_OUT_TO_A_BLOCK__ + 12",
        "30  CoreFoundation                      __CFRunLoopDoBlocks + 445",
        "31  CoreFoundation                      __CFRunLoopRun + 2609",
        "32  CoreFoundation                      CFRunLoopRunSpecific + 562",
        "33  HIToolbox                           RunCurrentEventLoopInMode + 292",
        "34  HIToolbox                           ReceiveNextEventCommon + 594",
        "35  HIToolbox                           _BlockUntilNextEventMatchingListInModeWithFilter + 70",
        "36  AppKit                              _DPSNextEvent + 927",
        "37  AppKit                              -[NSApplication(NSEvent) _nextEventMatchingEventMask:untilDate:inMode:dequeue:] + 1394",
        "38  ViewBridge                          __75-[NSViewServiceApplication nextEventMatchingMask:untilDate:inMode:dequeue:]_block_invoke + 111",
        "39  ViewBridge                          -[NSViewServiceApplication _withToxicEventMonitorPerform:] + 114",
        "40  ViewBridge                          -[NSViewServiceApplication nextEventMatchingMask:untilDate:inMode:dequeue:] + 151",
        "41  AppKit                              -[NSApplication run] + 586",
        "42  AppKit                              NSApplicationMain + 817",
        "43  libxpc.dylib                        _xpc_objc_main + 867",
        "44  libxpc.dylib                        xpc_main + 99",
        "45  Foundation                          +[NSXPCListener serviceListener] + 0",
        "46  PlugInKit                           __PLUGINKIT_CALLING_OUT_TO_CLIENT_SUBSYSTEM_FOR_BEGINUSING__ + 38962",
        "47  PlugInKit                           __PLUGINKIT_CALLING_OUT_TO_CLIENT_SUBSYSTEM_FOR_BEGINUSING__ + 38072",
        "48  PlugInKit                           __PLUGINKIT_CALLING_OUT_TO_CLIENT_SUBSYSTEM_FOR_BEGINUSING__ + 39937",
        "49  ExtensionFoundation                 EXExtensionMain + 284",
        "50  Foundation                          NSExtensionMain + 240",
        "51  MyFileProviderUiExtension           xamarin_main + 1107",
        "52  MyFileProviderUiExtension           xamarin_mac_extension_main + 32",
        "53  dyld                                start + 462"
    );
    name = NSInternalInconsistencyException;
    reason = "attempting to send message to non-existent action extension view controller";
}, com.apple.ViewBridge.error.description=NSViewBridgeServiceBootstrapError}

```
```


FP Custom action sheet failed to load with error Error Domain=com.apple.ViewBridge Code=14 "(null)" UserInfo={com.apple.ViewBridge.error.hint={
    callStackSymbols =     (
        "0   CoreFoundation                      __exceptionPreprocess + 242",
        "1   libobjc.A.dylib                     objc_exception_throw + 48",
        "2   Foundation                          -[NSAssertionHandler handleFailureInMethod:object:file:lineNumber:description:] + 267",
        "3   FileProviderUI                      -[FPUIActionExtensionContainerViewController _configureWithDomainIdentifier:] + 170",
        "4   FileProviderUI                      -[FPUIActionExtensionContainerViewController awakeFromRemoteView] + 851",
        "5   ViewBridge                          -[NSViewServiceMarshal _bootstrap:replyData:completion:] + 2235",
        "6   ViewBridge                          -[NSViewServiceMarshal bootstrap:withReply:] + 245",
        "7   CoreFoundation                      __invoking___ + 140",
        "8   CoreFoundation                      -[NSInvocation invoke] + 305",
        "9   CoreFoundation                      -[NSInvocation invokeWithTarget:] + 70",
        "10  ViewBridge                          -[NSVB_ViewServiceImplicitAnimationDecodingProxy forwardInvocation:] + 85",
        "11  CoreFoundation                      ___forwarding___ + 751",
        "12  CoreFoundation                      _CF_forwarding_prep_0 + 120",
        "13  CoreFoundation                      __invoking___ + 140",
        "14  CoreFoundation                      -[NSInvocation invoke] + 305",
        "15  CoreFoundation                      -[NSInvocation invokeWithTarget:] + 70",
        "16  ViewBridge                          -[NSVB_QueueingProxy forwardInvocation:] + 321",
        "17  CoreFoundation                      ___forwarding___ + 751",
        "18  CoreFoundation                      _CF_forwarding_prep_0 + 120",
        "19  CoreFoundation                      __invoking___ + 140",
        "20  CoreFoundation                      -[NSInvocation invoke] + 305",
        "21  CoreFoundation                      -[NSInvocation invokeWithTarget:] + 70",
        "22  CoreFoundation                      ___forwarding___ + 751",
        "23  CoreFoundation                      _CF_forwarding_prep_0 + 120",
        "24  CoreFoundation                      __invoking___ + 140",
        "25  CoreFoundation                      -[NSInvocation invoke] + 305",
        "26  ViewBridge                          __deferNSXPCInvocationOntoMainThread_block_invoke + 228",
        "27  ViewBridge                          __wrapBlockWithVoucher_block_invoke + 37",
        "28  ViewBridge                          __deferBlockOntoMainThread_block_invoke_2 + 274",
        "29  CoreFoundation                      __CFRUNLOOP_IS_CALLING_OUT_TO_A_BLOCK__ + 12",
        "30  CoreFoundation                      __CFRunLoopDoBlocks + 445",
        "31  CoreFoundation                      __CFRunLoopRun + 2609",
        "32  CoreFoundation                      CFRunLoopRunSpecific + 562",
        "33  HIToolbox                           RunCurrentEventLoopInMode + 292",
        "34  HIToolbox                           ReceiveNextEventCommon + 594",
        "35  HIToolbox                           _BlockUntilNextEventMatchingListInModeWithFilter + 70",
        "36  AppKit                              _DPSNextEvent + 927",
        "37  AppKit                              -[NSApplication(NSEvent) _nextEventMatchingEventMask:untilDate:inMode:dequeue:] + 1394",
        "38  ViewBridge                          __75-[NSViewServiceApplication nextEventMatchingMask:untilDate:inMode:dequeue:]_block_invoke + 111",
        "39  ViewBridge                          -[NSViewServiceApplication _withToxicEventMonitorPerform:] + 114",
        "40  ViewBridge                          -[NSViewServiceApplication nextEventMatchingMask:untilDate:inMode:dequeue:] + 151",
        "41  AppKit                              -[NSApplication run] + 586",
        "42  AppKit                              NSApplicationMain + 817",
        "43  libxpc.dylib                        _xpc_objc_main + 867",
        "44  libxpc.dylib                        xpc_main + 99",
        "45  Foundation                          +[NSXPCListener serviceListener] + 0",
        "46  PlugInKit                           __PLUGINKIT_CALLING_OUT_TO_CLIENT_SUBSYSTEM_FOR_BEGINUSING__ + 38962",
        "47  PlugInKit                           __PLUGINKIT_CALLING_OUT_TO_CLIENT_SUBSYSTEM_FOR_BEGINUSING__ + 38072",
        "48  PlugInKit                           __PLUGINKIT_CALLING_OUT_TO_CLIENT_SUBSYSTEM_FOR_BEGINUSING__ + 39937",
        "49  ExtensionFoundation                 EXExtensionMain + 284",
        "50  Foundation                          NSExtensionMain + 240",
        "51  MyFileProviderUiExtension           xamarin_main + 1107",
        "52  MyFileProviderUiExtension           xamarin_mac_extension_main + 32",
        "53  dyld                                start + 462"
    );
    name = NSInternalInconsistencyException;
    reason = "attempting to send message to non-existent action extension view controller";
}, com.apple.ViewBridge.error.description=NSViewBridgeServiceBootstrapError}
```

The same error is generated when I run the custom action on the folder/file inside the domain
