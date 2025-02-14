export type MenuItem = {
    href: string;
    icon: React.ComponentType;
    label: string;
    allowedRoles?: ('admin' | 'supplier')[];
  };
  
  export type SidebarGroup = {
    title: string;
    items: MenuItem[];
  };