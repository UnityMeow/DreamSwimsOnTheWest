Object:SubClass("MonoBase");
function MonoBase:Init()
    MonoManager.Instance:AddUpdateListener(self.Update);
end
function MonoBase:Update()
end

--[[ 使用说明
MonoBase:SubClass("Control");   --新建类 继承MonoBase
function Control1:Update()      --重写Udate
     print(1);
end
]]--

