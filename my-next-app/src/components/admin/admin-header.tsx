'use client'
import { useEffect, useState } from 'react';
import ThemeToggler from '../theme-toggler';
import Link from 'next/link';

interface HeaderProps {
  userName: string;
  userProfileUrl: string
}

const AdminPageHeader: React.FC<HeaderProps> = ({ userName, userProfileUrl }) => {

//   const {setCurrentUserId} =useAlgoleapContext() as AlgoleapContextType
  
  const [user, setUser] = useState({
    userName: 'Devanjan',
    userProfileUrl: '',
  });

 

  return (
    <header className="flex items-center justify-between px-6 py-4 bg-white dark:bg-[#17171A] border-b w-full shadow-bottom">
      <div className="flex items-center space-x-3">
        <img src='/PeoplePulseFinal1.png' height={50} width={50}/>
        <h1 className="text-xl font-bold text-gray-800 dark:text-white">PEOPLE PULSE</h1>
      </div>
<div>
  <h1  className="text-xl font-bold text-gray-800 dark:text-white">WORKFORCE MANAGEMENT</h1>
</div>
      {/* User Greeting & Profile Image */}
      <div className="flex items-center space-x-3">
      <ThemeToggler />
        <span className="text-sm text-gray-700 dark:text-green-100">
          Welcome, <strong>{user.userName || 'Guest'}</strong>
        </span>
        <Link href='/admin/profile'>
        <img
          src={user.userProfileUrl || userProfileUrl} // Update with the path to your profile image
          alt="User Profile"
          className="w-10 h-10 rounded-full border-2 border-gray-300"
        /></Link>
      </div>
    </header>
  );
};

export default AdminPageHeader;
