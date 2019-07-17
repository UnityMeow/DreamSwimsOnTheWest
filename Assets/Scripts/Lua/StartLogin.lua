PanelBase:SubClass("StartLogin")
function StartLogin:Show()
    -- 显示面板
    self.Base.panelName = "StartLogin";
    self.Base:Show();
    -- 添加控件事件
    self.panel:AddEventTrigger("sl_Close",EventTriggerType.PointerClick,self.CloseButton);
end
function StartLogin:CloseButton(data)
    StartLogin:Hide();
    --MySQLManager.Instance:Select("UserInfo",{"Password"},{"ID"},{"="},{"1"});
    -- 已登账号
        --加载切换账号面板
    -- 未登账号
        --加载登录面板
end