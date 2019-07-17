PanelBase:SubClass("StartHome")
function StartHome:Start()
end
function StartHome:Show()
    -- 显示面板
    self.Base.panelName = "StartHome";
    self.Base:Show();
    --StartHomePanel = UIManager.Instance:LuaShowPanel("StartHome");
    -- 添加控件事件
    self.panel:AddEventTrigger("sh_Login",EventTriggerType.PointerClick,self.OkButton);
    self.panel:AddEventTrigger("sh_ID",EventTriggerType.PointerClick,self.LoginButton);
end
--function StartHome:Hide(data)
    -- 隐藏面板
    --UIManager.Instance:HidePanel("StartHome");
--end
--function StartHome:Destroy(data)
    -- 销毁面板
    --UIManager.Instance:DestroyPanel("StartHome");
--end
-- 登录游戏逻辑
function StartHome:OkButton(data)
    StartHome.panel:GetGameObject("sh_Login").transform.localScale = Vector3(0.7,0.7,0.7);
    -- 已登账号
    --if PlayerInfoMgr.Instance:FindRecord()
    --then
        --移除主面板 进入游戏
        StartHome:Destroy();
        --显示游戏UI
        GameHome:Show();
    -- 未等账号
    --else
        --加载登录面板
    --    StartLogin:Show();
    --end 
end
function StartHome:LoginButton(data)
    --MySQLManager.Instance:OpenSql("127.0.0.1","3306","root","","gamedatabase");
    --MySQLManager.Instance:Insert("UserInfo",{"ID","Password"},{"'66666'","'99999'"});
    --MySQLManager.Instance:Select("UserInfo",{"Password"},{"ID"},{"="},{"1"});
    if PlayerInfoMgr.Instance:FindRecord()
    then

    end
    -- 已登账号
        --加载切换账号面板
    -- 未登账号
        --加载登录面板
end