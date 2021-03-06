﻿namespace HallOfFame.Web.Infrastructure.Helpers.Html
{
    using System;
    using System.Linq.Expressions;
    using System.Web.Mvc;

    using Kendo.Mvc.UI;
    using Kendo.Mvc.UI.Fluent;

    public static class KendoHelpers
    {
        public static GridBuilder<T> FullFeaturedGrid<T>(
            this HtmlHelper helper,
            string controllerName,
            Expression<Func<T, object>> modelIdExpression,
            Action<GridColumnFactory<T>> columns = null,
            Action<DataSourceBuilder<T>> dataSource = null,
            object readRouteValues = null) where T : class
        {
            if (columns == null)
            {
                columns = cols =>
                {
                    cols.AutoGenerate(true);
                    cols.Command(c => c.Edit());
                    cols.Command(c => c.Destroy());
                };
            }

            var kendoGrid =
                helper.Kendo()
                    .Grid<T>()
                    .Name("grid")
                    .Columns(columns)
                    .ColumnMenu()
                    .Pageable(page => page.Refresh(true))
                    .Sortable()
                    .Groupable()
                    .Filterable()
                    .Editable(edit => edit.Mode(GridEditMode.PopUp));

            if (dataSource == null)
            {
                dataSource =
                    data =>
                    data.Ajax().Model(m => m.Id(modelIdExpression)).Read(read => read.Action("Read", controllerName))
                        /*.Create(create => create.Action("Create", controllerName))*/
                        .Update(update => update.Action("Update", controllerName))
                        .Destroy(destroy => destroy.Action("Destroy", controllerName));
            }
            else
            {
                kendoGrid.ToolBar(toolbar => toolbar.Create());
            }

            kendoGrid.DataSource(dataSource);

            return kendoGrid;
        }
    }
}