Object:SubClass("StartSwitchID")
function StartSwitchID:Show()
    --显示面板
    StartSwitchIDPanel = UIManager.Instance:LuaShowPanel("StartSwitchID");
    -- 添加控件事件
    StartSwitchIDPanel:AddEventTrigger("sr_Close",EventTriggerType.PointerClick,StartSwitchIDPanel.CloseButton);
end
function StartSwitchID:Hide(data)
    -- 隐藏面板
    UIManager.Instance:HidePanel("StartSwitchID");
    
end
function StartSwitchID:CloseButton(data)
    StartSwitchID:Hide();
end