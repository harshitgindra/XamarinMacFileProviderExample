using System;
using FileProvider;
using Foundation;
using ObjCRuntime;

namespace MyFileProviderExtension
{
    [Register("FileProviderDriver")]
    public class FileProviderDriver: NSExtensionRequestHandling, INSFileProviderReplicatedExtension
    {
        [Export("initWithDomain:")]
        public FileProviderDriver(NSFileProviderDomain domain)
        {
        }

        public override void BeginRequestWithExtensionContext(NSExtensionContext context)
        {
        }


        public NSProgress CreateItem(INSFileProviderItem itemTemplate, NSFileProviderItemFields fields, NSUrl url, NSFileProviderCreateItemOptions options, NSFileProviderRequest request, NSFileProviderCreateOrModifyItemCompletionHandler completionHandler)
        {
            return null;
        }

        public NSProgress DeleteItem(string identifier, NSFileProviderItemVersion version, NSFileProviderDeleteItemOptions options, NSFileProviderRequest request, Action<NSError> completionHandler)
        {
            return null;
        }


        public NSProgress FetchContents(string itemIdentifier, NSFileProviderItemVersion requestedVersion, NSFileProviderRequest request, NSFileProviderFetchContentsCompletionHandler completionHandler)
        {
            return null;
        }

        public INSFileProviderEnumerator GetEnumerator(string containerItemIdentifier, NSFileProviderRequest request, out NSError error)
        {
            error = NSError.FromDomain(new NSString("NSFileProviderErrorDomain"),
                (int)NSFileProviderError.NotAuthenticated, null);

            return null;
        }

        public NSProgress GetItem(string identifier, NSFileProviderRequest request, Action<INSFileProviderItem, NSError> completionHandler)
        {
            return null;
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

