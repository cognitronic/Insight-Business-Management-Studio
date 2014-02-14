/// <reference path="jquery-1.4.1.js" />
///<reference name="Telerik.Web.UI.Common.Core.js" assembly="Telerik.Web.UI"/>

function test()
{
    alert('fuck');
    var combo = new Telerik.Web.UI.RadComboBox();
    var comboItem = new Telerik.Web.UI.RadComboBoxItem();
    comboItem.set_text("item");
    combo.trackChanges();
    combo.get_items().add(comboItem);
    comboItem.select();
    combo.commitChanges(); 
    return combo;
}