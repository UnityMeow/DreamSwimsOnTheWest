Object:SubClass("PanelBase")
PanelBase.panelName = "";
PanelBase.panel = nil;
PanelBase.isInit = false;
function PanelBase:Init()
end
function PanelBase:Show()
    self.panel = UIManager.Instance:LuaShowPanel(self.panelName);
    if self.isInit then
        return;
    end
    self.Init();
    self.isInit = true;
end
function PanelBase:Hide()
    UIManager.Instance:HidePanel(self.panelName);
end
function PanelBase:Destroy()
    UIManager.Instance:DestroyPanel(self.panelName);
    self.isInit = false;
    self.panel = nil;
end