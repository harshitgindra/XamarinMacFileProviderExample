using System;
using FileProvider;
using Foundation;
using ObjCRuntime;
using UniformTypeIdentifiers;

namespace MyFileProviderExtension
{
    public class FileProviderItem : NSObject, INSFileProviderItem
    {
        public string Identifier;
        public FileProviderItem (string identifier)
        {
            Identifier = identifier;
        }


        string INSFileProviderItem.Identifier => Identifier;
        string INSFileProviderItem.ParentIdentifier => NSFileProviderItemIdentifier.RootContainer;
        string INSFileProviderItem.Filename => Identifier;
        string INSFileProviderItem.TypeIdentifier => Identifier == NSFileProviderItemIdentifier.RootContainer ? UTTypes.Folder.ToString() : UTTypes.PlainText.ToString();
    }

    public class FileProviderEnumerator : NSObject, INSFileProviderEnumerator
    {
        string ContainerItemIdentifier;
        public FileProviderEnumerator (string containerItemIdentifier)
        {
            ContainerItemIdentifier = containerItemIdentifier;
        }


        void INSFileProviderEnumerator.EnumerateItems(INSFileProviderEnumerationObserver observer, NSData startPage)
        {
            observer.DidEnumerateItems(new INSFileProviderItem[] { });
            observer.FinishEnumerating((NSData)null);
        }

        void INSFileProviderEnumerator.Invalidate()
        {
        }
    }


    [Register("FileProviderDriver")]
    public class FileProviderDriver: NSExtensionRequestHandling, INSFileProviderReplicatedExtension
    {
        [Export("initWithDomain:")]
        public FileProviderDriver()
        {
        }

        public override void BeginRequestWithExtensionContext(NSExtensionContext context)
        {
        }


        public NSProgress CreateItem(INSFileProviderItem itemTemplate, NSFileProviderItemFields fields, NSUrl url, NSFileProviderCreateItemOptions options, NSFileProviderRequest request, NSFileProviderCreateOrModifyItemCompletionHandler completionHandler)
        {
            completionHandler(itemTemplate, fields, false, null);
            return new NSProgress ();
        }

        public NSProgress DeleteItem(string identifier, NSFileProviderItemVersion version, NSFileProviderDeleteItemOptions options, NSFileProviderRequest request, Action<NSError> completionHandler)
        {
            completionHandler(new NSError(NSError.CocoaErrorDomain, 3328));
            return new NSProgress();
        }


        public NSProgress FetchContents(string itemIdentifier, NSFileProviderItemVersion requestedVersion, NSFileProviderRequest request, NSFileProviderFetchContentsCompletionHandler completionHandler)
        {
            completionHandler(null, null, new NSError(NSError.CocoaErrorDomain, 3328));
            return new NSProgress();
        }

        public INSFileProviderEnumerator GetEnumerator(string containerItemIdentifier, NSFileProviderRequest request, out NSError error)
        {
            error = null;
            return new FileProviderEnumerator(containerItemIdentifier);
        }

        public NSProgress GetItem(string identifier, NSFileProviderRequest request, Action<INSFileProviderItem, NSError> completionHandler)
        {
            completionHandler(new FileProviderItem(identifier), null);
            return new NSProgress();
        }

        public void Invalidate()
        {
        }

        public NSProgress ModifyItem(INSFileProviderItem item, NSFileProviderItemVersion version, NSFileProviderItemFields changedFields, NSUrl newContents, NSFileProviderModifyItemOptions options, NSFileProviderRequest request, NSFileProviderCreateOrModifyItemCompletionHandler completionHandler)
        {
            return null;
        }
    }
}

