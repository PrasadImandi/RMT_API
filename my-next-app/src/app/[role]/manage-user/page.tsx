import AdminTableUser from '@/components/appComp/admin/admin-user-table'
import { Button } from '@/components/ui/button'
import Link from 'next/link'
import { Suspense } from 'react'

const ManageProject = () => {
  return (
    <div className='p-16'>
      <div className='flex justify-between items-center pb-6'>
         <h1 className='text-2xl font-medium text-primary-one'>Manage Users</h1>
         <Button className='px-4 dark:bg-blue-400' asChild>
          <Link href='/admin/manage-user/add-user'>Add users</Link>
         </Button>
      </div>
      <Suspense fallback={<p>Loading Project table...</p>}>
      <AdminTableUser />
      </Suspense>
    </div>
  )
}

export default ManageProject