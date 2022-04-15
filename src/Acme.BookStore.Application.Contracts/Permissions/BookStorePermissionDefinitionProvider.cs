using Acme.BookStore.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Acme.BookStore.Permissions;

public class BookStorePermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var bookStoreGroup = context.AddGroup(BookStorePermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(BookStorePermissions.MyPermission1, L("Permission:MyPermission1"));
        var nCCsPermission = bookStoreGroup.AddPermission(BookStorePermissions.NhaCungCaps.Default, L("Permission:NhaCungCaps"));
        nCCsPermission.AddChild(BookStorePermissions.NhaCungCaps.Create, L("Permission:NhaCungCaps.Create"));
        nCCsPermission.AddChild(BookStorePermissions.NhaCungCaps.Edit, L("Permission:NhaCungCaps.Edit"));
        nCCsPermission.AddChild(BookStorePermissions.NhaCungCaps.Delete, L("Permission:NhaCungCaps.Delete"));

        var booksPermission = bookStoreGroup.AddPermission(BookStorePermissions.Books.Default, L("Permission:Books"));
        booksPermission.AddChild(BookStorePermissions.Books.Create, L("Permission:Books.Create"));
        booksPermission.AddChild(BookStorePermissions.Books.Edit, L("Permission:Books.Edit"));
        booksPermission.AddChild(BookStorePermissions.Books.Delete, L("Permission:Books.Delete"));

        var authorsPermission = bookStoreGroup.AddPermission(BookStorePermissions.Authors.Default, L("Permission:Authors"));

        authorsPermission.AddChild(BookStorePermissions.Authors.Create, L("Permission:Authors.Create"));
        authorsPermission.AddChild(BookStorePermissions.Authors.Edit, L("Permission:Authors.Edit"));
        authorsPermission.AddChild(BookStorePermissions.Authors.Delete, L("Permission:Authors.Delete"));

    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<BookStoreResource>(name);
    }
}
