﻿using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Threading.Tasks;

namespace BootstrapBlazor.Components
{
    /// <summary>
    /// 动态元素组件
    /// </summary>
    public class DynamicElement : BootstrapComponentBase
    {
        /// <summary>
        /// 获得/设置 TagName 属性 默认为 div
        /// </summary>
        [Parameter]
        public string? TagName { get; set; } = "div";

        /// <summary>
        /// 获得/设置 是否触发 Click 事件 默认 true
        /// </summary>
        [Parameter]
        public bool TriggerClick { get; set; } = true;

        /// <summary>
        /// 获得/设置 Click 回调委托
        /// </summary>
        [Parameter]
        public Func<Task>? OnClick { get; set; }

        /// <summary>
        /// 获得/设置 是否触发 DoubleClick 事件 默认 true
        /// </summary>
        [Parameter]
        public bool TriggerDoubleClick { get; set; } = true;

        /// <summary>
        /// 获得/设置 DoubleClick 回调委托
        /// </summary>
        [Parameter]
        public Func<Task>? OnDoubleClick { get; set; }

        /// <summary>
        /// 获得/设置 内容组件
        /// </summary>
        [Parameter]
        public RenderFragment? ChildContent { get; set; }

        /// <summary>
        /// BuildRenderTree 方法
        /// </summary>
        /// <param name="builder"></param>
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, TagName);
            if (AdditionalAttributes != null) builder.AddMultipleAttributes(1, AdditionalAttributes);
            if (TriggerClick && OnClick != null) builder.AddAttribute(2, "onclick", EventCallback.Factory.Create<MouseEventArgs>(this, e => OnClick()));
            if (TriggerDoubleClick && OnDoubleClick != null) builder.AddAttribute(3, "ondblclick", EventCallback.Factory.Create<MouseEventArgs>(this, e => OnDoubleClick()));
            builder.AddContent(4, ChildContent);
            builder.CloseElement();
        }
    }
}
