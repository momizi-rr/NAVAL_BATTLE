<?php
namespace App\Controller;

use App\Controller\AppController;

/**
 * Shootingleveldesign Controller
 *
 * @property \App\Model\Table\ShootingleveldesignTable $Shootingleveldesign
 *
 * @method \App\Model\Entity\Shootingleveldesign[]|\Cake\Datasource\ResultSetInterface paginate($object = null, array $settings = [])
 */
class ShootingleveldesignController extends AppController
{

    /**
     * Index method
     *
     * @return \Cake\Http\Response|void
     */
    public function index()
    {
        $shootingleveldesign = $this->paginate($this->Shootingleveldesign);

        $this->set(compact('shootingleveldesign'));
    }

    /**
     * View method
     *
     * @param string|null $id Shootingleveldesign id.
     * @return \Cake\Http\Response|void
     * @throws \Cake\Datasource\Exception\RecordNotFoundException When record not found.
     */
    public function view($id = null)
    {
        $shootingleveldesign = $this->Shootingleveldesign->get($id, [
            'contain' => []
        ]);

        $this->set('shootingleveldesign', $shootingleveldesign);
    }

    /**
     * Add method
     *
     * @return \Cake\Http\Response|null Redirects on successful add, renders view otherwise.
     */
    public function add()
    {
        $shootingleveldesign = $this->Shootingleveldesign->newEntity();
        if ($this->request->is('post')) {
            $shootingleveldesign = $this->Shootingleveldesign->patchEntity($shootingleveldesign, $this->request->getData());
            if ($this->Shootingleveldesign->save($shootingleveldesign)) {
                $this->Flash->success(__('The shootingleveldesign has been saved.'));

                return $this->redirect(['action' => 'index']);
            }
            $this->Flash->error(__('The shootingleveldesign could not be saved. Please, try again.'));
        }
        $this->set(compact('shootingleveldesign'));
    }

    /**
     * Edit method
     *
     * @param string|null $id Shootingleveldesign id.
     * @return \Cake\Http\Response|null Redirects on successful edit, renders view otherwise.
     * @throws \Cake\Datasource\Exception\RecordNotFoundException When record not found.
     */
    public function edit($id = null)
    {
        $shootingleveldesign = $this->Shootingleveldesign->get($id, [
            'contain' => []
        ]);
        if ($this->request->is(['patch', 'post', 'put'])) {
            $shootingleveldesign = $this->Shootingleveldesign->patchEntity($shootingleveldesign, $this->request->getData());
            if ($this->Shootingleveldesign->save($shootingleveldesign)) {
                $this->Flash->success(__('The shootingleveldesign has been saved.'));

                return $this->redirect(['action' => 'index']);
            }
            $this->Flash->error(__('The shootingleveldesign could not be saved. Please, try again.'));
        }
        $this->set(compact('shootingleveldesign'));
    }

    /**
     * Delete method
     *
     * @param string|null $id Shootingleveldesign id.
     * @return \Cake\Http\Response|null Redirects to index.
     * @throws \Cake\Datasource\Exception\RecordNotFoundException When record not found.
     */
    public function delete($id = null)
    {
        $this->request->allowMethod(['post', 'delete']);
        $shootingleveldesign = $this->Shootingleveldesign->get($id);
        if ($this->Shootingleveldesign->delete($shootingleveldesign)) {
            $this->Flash->success(__('The shootingleveldesign has been deleted.'));
        } else {
            $this->Flash->error(__('The shootingleveldesign could not be deleted. Please, try again.'));
        }

        return $this->redirect(['action' => 'index']);
    }

    //データベースからメッセージを取得するAction
    public function getMessages()
    {
        //エラーした場合の表示
        error_log("getMessage()");
    
        //ビューのレンダーを無効化。これでテンプレートが無くてもアクションが使える様になる
        $this->autoRender = false;
    
        //Postデータのnumberを受け取り(使ってない？)
        // $number = $this->request->getData("number");
    
        //データベースのテーブルからデータを取得
        $query = $this->Shootingleveldesign->find('all');
    
        //取得データをJson形式に変換
        $json_array = json_encode($query);
    
        //出力
        echo $json_array;
    }

    public function setMessages()
    {
        //エラーした場合の表示
        error_log("setMessage()");

        //テンプレートが無くてもアクションが使える様に
        $this->autoRender = false;

        //Postデータの受け取り口を作る
        $level       = $this->request->getData('level');
        $pattern    = $this->request->getData('pattern');
        $pos_x       = $this->request->getData('pos_x ');
        $pos_y    = $this->request->getData('pos_y');
        $pos_z       = $this->request->getData('pos_z');
        $rote_x    = $this->request->getData('rote_x');
        $rote_y       = $this->request->getData('rote_y');
        $rote_z    = $this->request->getData('rote_z');
        $scale_x    = $this->request->getData('scale_x');
        $scale_y       = $this->request->getData('scale_y');
        $scale_z    = $this->request->getData('scale_z');

        //テーブルの各々のカラムに情報を追加
        $data	= array ( 'Level' => $level, 'Pattern' => $pattern,
                        'PosX' => $pos_x, 'PosY' => $pos_y, 'PosZ' => $pos_z,
                        'RateX' => $rote_x, 'PosY' => $rote_y, 'PosZ' => $rote_z,
                        'ScaleX' => $scale_x, 'ScaleY' => $scale_y, 'ScaleZ' => $scale_z
                        );	//timestamp型
        
        $shootingleveldesign = $this->Shootingleveldesign->newEntity();                       //レコードの作成
        $shootingleveldesign = $this->Shootingleveldesign->patchEntity($shootingleveldesign, $data); //レコードにデータ追加を更新
        
        //レコードの保存
        if($this->Shootingleveldesign->save($shootingleveldesign))    //成功した場合
        {
            echo "1";
        }
        else                                            //失敗した場合
        {
            echo "0";
        }
    }
}